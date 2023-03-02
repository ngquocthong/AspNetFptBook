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
using System.Text;

namespace WebClient.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "Customer")]

    public class CartController : Controller
    {
        public /*const*/ string CARTKEY = "cart";

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
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var KEY = CARTKEY + userID.ToString();
            var session = HttpContext.Session;
            string jsoncart = session.GetString(KEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }
        //Clear session of Cart
        void ClearCart()
        {

            List<CartItem> cart = GetCartItems();
            cart.Clear();
            SaveCartSession(cart);

        }
        void SaveCartSession(List<CartItem> ls)
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var KEY = CARTKEY + userID.ToString();
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(KEY, jsoncart);
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
           
			or.OrderDetails = new List<OrderDetails>();
			foreach (var item in cart)
            {
                OrderDetails od = new OrderDetails();
                od.book_id = item.book.ID;
                od.quantity = item.quantity;
				or.totalPrice += item.quantity * item.book.book_price;
                od.Order = or;
                or.owner_id = item.book.owner_id;
                od.Book = item.book;
                or.OrderDetails.Add(od);
                var bookApi = "https://localhost:7186/api/Book/" + item.book.ID;
                var bookDetails = await GetBookDetails(bookApi);
                bookDetails.quantity -= item.quantity;
                
                await UpdateBookDetails(bookApi, bookDetails);
            }
			string data = JsonSerializer.Serialize<Order>(or);
			var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage respon = await client.PostAsync(api, content);
           
            if (respon.StatusCode == System.Net.HttpStatusCode.NoContent)
			{
                ClearCart();
                return RedirectToAction("Index", "Order");
			}
            
            return View();
		}

        private async Task<IActionResult> UpdateBookDetails(string bookApi, Book bookDetails)
        {

            string data = JsonSerializer.Serialize<Book>(bookDetails);
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(bookApi, content);
            if (response.IsSuccessStatusCode)
            {
                return NoContent();
            }
            return NoContent();
            
        }
     
        private async Task<Book> GetBookDetails(string bookApi)
        {

            HttpResponseMessage response = await client.GetAsync(bookApi);
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var obj = JsonSerializer.Deserialize<Book>(data, options);
                return obj;
            }
            throw new NotImplementedException();
        }



        //public IActionResult CheckOut([FromForm] string email, [FromForm] string address)


    }
}
