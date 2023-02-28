using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using BusinessObjects;
using System.Text.Json;
using System.Security.Claims;

namespace WebClient.Areas.Customer.Controllers
{
	[Area("Customer")]
	[Authorize(Roles = "Customer")]
	public class OrderController : Controller
	{
        private readonly HttpClient client = null;
        private string api;
		public OrderController()
		{
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
			api = "https://localhost:7186/api/"; 
        }
		
		[HttpGet]
        public async Task<ActionResult> Index()
		{
			api = api + "Orders";
			var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            HttpResponseMessage response = await client.GetAsync(api);
            string data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Order> list = JsonSerializer.Deserialize<List<Order>>(data, options);
            List<Order> filteredOrders = list.Where(order => order.cus_id == userID).ToList();
            return View(filteredOrders);
		}

		// GET: CheckoutController/Details/5

		public async Task<ActionResult> Details(int id)
		{
			try
			{
				api = api + "OrderDetails";
				HttpResponseMessage response = await client.GetAsync(api + "/" + id);
				HttpResponseMessage responseBook = await client.GetAsync("https://localhost:7186/api/Book");
				if (response.IsSuccessStatusCode)
				{
					var data = response.Content.ReadAsStringAsync().Result;
					var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
					var obj = JsonSerializer.Deserialize<List<OrderDetails>>(data, options);
					
					var dataBook = responseBook.Content.ReadAsStringAsync().Result;
					ViewBag.Books = JsonSerializer.Deserialize<List<Book>>(dataBook, options);
					return View(obj);
				}
				return Ok();

			}
			catch (JsonException ex)
			{
				// Handle the exception
				// Return an error view or redirect to an error page
				return RedirectToAction("Index", "Error");
			} 
		}

		// GET: CheckoutController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CheckoutController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CheckoutController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: CheckoutController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CheckoutController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: CheckoutController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
