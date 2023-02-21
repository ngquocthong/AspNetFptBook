using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repositories;

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

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Get(int id) => repository.GetBookByID(id);
        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post(Book b)
        {
           /* bool Results = false;
            try
            {
                var _uploadedfiles = Request.Form.Files;
                foreach (IFormFile source in _uploadedfiles)
                {
                    string Filename = source.FileName;
                    string Filepath = GetFilePath(Filename);

                    if (!System.IO.Directory.Exists(Filepath))
                    {
                        System.IO.Directory.CreateDirectory(Filepath);
                    }

                    string imagepath = Filepath + "\\image.png";

                    if (System.IO.File.Exists(imagepath))
                    {
                        System.IO.File.Delete(imagepath);
                    }
                    using (FileStream stream = System.IO.File.Create(imagepath))
                    {
                        source.CopyTo(stream);
                        Results = true;
                    }


                }
            }
            catch (Exception ex)
            {

            }
            return Ok(Results);*/

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


        [NonAction]
        private string GetFilePath(string ProductCode)
        {
            return this._environment.WebRootPath + "\\Uploads\\Product\\" + ProductCode;
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
