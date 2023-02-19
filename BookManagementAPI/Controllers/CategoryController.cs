using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // GET: api/<CategoryController>
        ICategoryRepository repository = new CateroryRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get() => repository.GetCategories();

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post(Category c)
        {
            repository.AddCategory(c);
            return NoContent();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Category c) 
        {
            var temp = repository.GetCateByID(id);
            if (c == null) return NotFound();
            repository.UpdateCate(c);    
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var c = repository.GetCateByID(id);
            if(c == null)
            {
                return NotFound();
      
            }
            repository.DeleteCategory(c);
            return NoContent();
        }
    }
}
