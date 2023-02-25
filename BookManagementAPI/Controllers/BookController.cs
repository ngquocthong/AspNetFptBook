using BusinessObjects;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repositories;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        IBookRepository repository = new BookRepository();
        private readonly IWebHostEnvironment _environment;
        public BookController(IWebHostEnvironment environment)
        {
            this._environment = environment;
        }
        // GET: api/<BookController>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get() => repository.GetBooks();
        [HttpGet("image/{bookId}")]
        public IActionResult GetBookImage(int bookId)
        {
            try { 
            var book = repository.GetBookByID(bookId);
            string imagePath = book.book_img;
            string imageName = Path.GetFileName(imagePath); // imageName is "tong-thong-nga-311222.jpg"
            string root = Path.Combine(_environment.WebRootPath, "images", imageName);
            var image = System.IO.File.OpenRead(root);
            return File(image, "image/jpg");
            } catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        public Book Get(int id) => repository.GetBookByID(id);
        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post(Book b)
        {
           
            repository.AddBook(b);
            return NoContent();
        }

        [HttpPost]
        [Route("uploadfile")]
        public async Task<IActionResult> PostWithImgJsonAsync([FromForm] string datajson, IFormFile fileImage)
        {
            var b = JsonConvert.DeserializeObject<Book>(datajson);
            
            
            if (fileImage.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileImage.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await fileImage.CopyToAsync(stream);
                }
                b.book_img = "/images/" + fileImage.FileName;

            }
            else b.book_img = "";
            repository.AddBook(b);
            return Ok(b);
        }
        [HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, [FromForm] string datajson, IFormFile fileImage)
        public async Task<IActionResult> Put(int id, [FromForm] string datajson)
        {
            var bookToUpdate = repository.GetBookByID(id);

            if (bookToUpdate == null)
            {
                return NotFound();
            }

            var b = JsonConvert.DeserializeObject<Book>(datajson);
            bookToUpdate.book_name = b.book_name;
            bookToUpdate.book_author = b.book_author;
            bookToUpdate.cate_id = b.cate_id;
            bookToUpdate.book_price = b.book_price;
/*
            if (fileImage != null && fileImage.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileImage.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await fileImage.CopyToAsync(stream);
                }
                bookToUpdate.book_img = "/images/" + fileImage.FileName;
            }*/

            repository.UpdateBook(bookToUpdate);
            return Ok(bookToUpdate);
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
