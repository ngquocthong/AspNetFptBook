using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderRepository repository = new OrderRepository();
        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get() => repository.GetOrders();

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
       

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post(Order o)
        {
            repository.AddOrder(o);
            return NoContent();
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Order c)
        {
            var temp = repository.GetOrderByID(id);
            if (c == null) return NotFound();
            repository.UpdateOrder(c);
            return NoContent();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var c = repository.GetOrderByID(id);
            if (c == null)
            {
                return NotFound();

            }
            repository.DeleteOrder(c);
            return NoContent();
        }
    }
}
