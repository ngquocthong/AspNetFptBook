using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text.Json;
using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace WebClient.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "Customer")]

    public class CartController : Controller
    {
        public const string CARTKEY = "cart";

        private readonly HttpClient client = null;
        private string api;
        private readonly ILogger<BookController> _logger;
        public CartController(ILogger<BookController>? logger)
        {

            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            api = "https://localhost:7186/api";
            _logger = logger;
        }

        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }
        //Clear session of Cart
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }
        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }
        [Route("/cart", Name = "cart")]
        public IActionResult Cart()
        {
            return View(GetCartItems());
        }

        // GET: CartController/Create

        public async Task<ActionResult> AddToCart(int id)
        {
            api = api + "/Book";

			HttpResponseMessage response = await client.GetAsync(api + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var obj = JsonSerializer.Deserialize<Book>(data, options);
                var book = obj;
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				var cart = GetCartItems();
                var cartitem = cart.Find(b => b.book.ID == id);
                if (cartitem != null)
                {
                    cartitem.quantity++;
                }
                else
                {
                    cart.Add(new CartItem() { quantity = 1, book = book, cus_id = userId});
                }
                SaveCartSession(cart);
                return RedirectToAction(nameof(Cart));
            }
            return NotFound();
             
        }

        // GET: CartController/Edit/5
        [Route("/updatecart", Name = "updatecart")]
        [HttpPost]
        public IActionResult UpdateCart([FromForm] int productid, [FromForm] int quantity)
        {
            // Cập nhật Cart thay đổi số lượng quantity ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.book.ID == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.quantity = quantity;
            }
            SaveCartSession(cart);
            // Trả về mã thành công (không có nội dung gì - chỉ để Ajax gọi)
            return Ok();
        }


        /// xóa item trong cart
        [Route("/removecart/{productid:int}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute] int productid)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.book.ID == productid);
            if (cartitem != null)
            {
                if (cartitem.quantity > 1)
                {
                    cartitem.quantity--;
                }
                else { cart.Remove(cartitem); }
                // Đã tồn tại, tăng thêm 1
                
            }

            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }
		public async Task<IActionResult> CheckOut(string userID)
		{
			api = api + "/Orders";
			var orderDetails = new OrderDetails();
			var cart = GetCartItems();
			Order or = new Order();
            or.totalPrice = 0;
            or.cus_id = userID;
            or.createdDate = DateTime.Now;
			or.shippingAddress = "ABC";

			foreach (var item in cart)
            {
                OrderDetails od = new OrderDetails();
                od.book_id = item.book.ID;
                od.quantity = item.quantity;
				or.totalPrice += item.quantity * item.book.book_price;
                od.Order = or;
                od.Book = item.book;
                if (od != null)
                    or.OrderDetails = new List<OrderDetails>();
                or.OrderDetails.Add(od);


            }

			// gan 


			string data = JsonSerializer.Serialize<Order>(or);

		    
			var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage respon = await client.PostAsync(api, content);
			if (respon.StatusCode == System.Net.HttpStatusCode.NoContent)
			{
				return RedirectToAction("Index");
			}
            return View();
			
		}


		//public IActionResult CheckOut([FromForm] string email, [FromForm] string address)


	}
}
