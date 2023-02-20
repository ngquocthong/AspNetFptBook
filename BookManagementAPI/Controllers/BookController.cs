using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookRepository repository = new BookRepository();
        // GET: api/<BookController>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get() => repository.GetBooks();

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Get(int id) => repository.GetBookByID(id);
        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post(Book b)
        {
            repository.AddBook(b);
            return NoContent();
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Book b)
        {
            var temp = repository.GetBookByID(id);
            if (b == null) return NotFound();
            repository.UpdateBook(b);
            return NoContent();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var b = repository.GetBookByID(id);
            if (b == null)
            {
                return NotFound();

            }
            repository.DeleteBook(b);
            return NoContent();
        }
    }
}
