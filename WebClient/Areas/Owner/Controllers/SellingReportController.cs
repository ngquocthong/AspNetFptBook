using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using static NuGet.Packaging.PackagingConstants;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebClient.Areas.Owner.Controllers
{
    [Area("Owner")]

    public class SellingReportController : Controller
    {
        private readonly HttpClient client = null;
        private string api;
        public SellingReportController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            api = "https://localhost:7186/api/";
        }
        // GET: SellingReport
        public async Task<ActionResult> Index()
        {
            ViewBag.ownerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            try
            {
                HttpResponseMessage response = await client.GetAsync(api+ "Orders");
                string data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                List<Order> orders = JsonSerializer.Deserialize<List<Order>>(data, options);

                HttpResponseMessage response1 = await client.GetAsync(api+ "OrderDetails");
                string data1 = await response1.Content.ReadAsStringAsync();
                var options1 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                List<OrderDetails> orderDetails = JsonSerializer.Deserialize<List<OrderDetails>>(data1, options1);

				HttpResponseMessage response2 = await client.GetAsync(api + "Book");
				string data2 = await response2.Content.ReadAsStringAsync();
				var options2 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				List<Book> books = JsonSerializer.Deserialize<List<Book>>(data2, options2);
				// Join orders with order details
				List<Order> ordersWithDetails = orders.Select(order =>
                {
                    order.OrderDetails = orderDetails.Where(od => od.order_id == order.ID).ToList();
                    return order;
                }).ToList();

                // Join orders with order details
                List<Order> filteredOrders = ordersWithDetails.Where(order => order.owner_id == ViewBag.ownerID).ToList();

                int numberOfBooks = filteredOrders.Sum(o => o.OrderDetails.Sum(od => od.quantity));
				ViewBag.numberOfBooks = numberOfBooks;
				var topSellingBooks = filteredOrders.SelectMany(o => o.OrderDetails)
									 .GroupBy(od => od.book_id)
									 .Select(g => new { BookId = g.Key, Quantity = g.Sum(od => od.quantity) })
									 .Join(books, g => g.BookId, b => b.ID, (g, b) => new { Book = b, Quantity = g.Quantity })
									 .OrderByDescending(g => g.Quantity)
									 .Select(g => g.Book)
									 .ToList();

                ViewBag.allBook = books.Sum(b => b.quantity);

				ViewBag.topSellingBooks = topSellingBooks;


			
                
            }
            catch (JsonException ex)
            {
                return View();
            }

            return View();
        }

        // GET: SellingReport/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SellingReport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SellingReport/Create
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

        // GET: SellingReport/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SellingReport/Edit/5
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

        // GET: SellingReport/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SellingReport/Delete/5
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
