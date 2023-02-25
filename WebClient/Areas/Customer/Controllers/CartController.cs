using System.Security.Cryptography;
using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebClient.Areas.Customer.Controllers;
using WebClient.Models;

namespace WebClient.Controllers
{
    [Route("/books")]
    public class CartController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly ApplicationDbContext? _context;
        public CartController(ILogger<BookController>? logger, ApplicationDbContext? context)
        {
            _logger = logger;
            _context = context;
        }
        public const string CARTKEY = "cart";

        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if(jsoncart != null)
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
            return View();
        }

        // GET: CartController/Create
        [Route("addcart/{bookid:int}", Name = "addcart")]
        public ActionResult AddToCart(int bookid)
        {   
            var book = _context.Books
                        .Where(b => b.ID== bookid)
                        .FirstOrDefault();
            if (book == null) return NotFound("Not Found books");

            var cart = GetCartItems();
            var cartitem = cart.Find(b => b.book.ID == bookid);
            if(cartitem != null)
            {
                cartitem.quantity++;
            } else
            {
                cart.Add(new CartItem() { quantity = 1, book = book });
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof (Cart));
        }

        // GET: CartController/Edit/5
        [Route ("/updatecart", Name = "updatecart")]
        [HttpPost]
        public ActionResult UpdateCart(int id, int quantity)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find (b => b.book.ID == id);
            if(cartitem != null)
            {
                cartitem.quantity = quantity;
            }
            SaveCartSession(cart);
            return Ok();
        }


        [Route("/removecart/{productid:int}", Name = "removecart")]
        public IActionResult RemoveCart( int id)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(b => b.book.ID == id);
            if (cartitem != null)
            {
                cart.Remove(cartitem);
            }

            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }
    }
}
