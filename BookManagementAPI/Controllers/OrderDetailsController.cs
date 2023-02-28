using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace BookManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase
	{
		IOrderDetailsRepository repository = new OrderDetailsRepository();
		// GET: api/<OrdersController>
		[HttpGet]
		public ActionResult<IEnumerable<OrderDetails>> Get() => repository.GetOrderDetails();

		// GET api/<OrdersController>/5
		[HttpGet("{id}")]
		public List<OrderDetails> Get(int id) => repository.GetOrderDetailsByID(id);

		// POST api/<OrdersController>
		/*[HttpPost]
		public IActionResult Post(OrderDetails o)
		{
			repository.AddOrderDetails(o);
			return NoContent();
		}*/

		// PUT api/<OrdersController>/5
		/*[HttpPut("{id}")]
		public IActionResult Put(int id, OrderDetails c)
		{
			var temp = repository.GetOrderDetailsByID(id);
			if (c == null) return NotFound();
			repository.UpdateOrderDetails(c);
			return NoContent();
		}*/

		// DELETE api/<OrdersController>/5
		/*[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var c = repository.GetOrderDetailsByID(id);
			if (c == null)
			{
				return NotFound();

			}
			repository.DeleteOrderDetails(c);
			return NoContent();
		}*/
	}
}
