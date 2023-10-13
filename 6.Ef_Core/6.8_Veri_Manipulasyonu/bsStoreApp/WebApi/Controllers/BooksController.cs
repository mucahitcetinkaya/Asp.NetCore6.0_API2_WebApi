using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public BooksController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _context.Books.ToList();
                return Ok(books);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var book = _context.Books.Where(b => b.Id.Equals(id)).SingleOrDefault();

                if (book is null)
                {
                    return NotFound(); // 404
                }
                return Ok(book);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest(); // 400
                _context.Books.Add(book);
                _context.SaveChanges();
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            try
            {
                // check book varsa bulduk 
                var entity = _context
                    .Books
                    .Where(b => b.Id.Equals(id)) // where yazmamızın nedeni onu track edecek izleyecek
                    .SingleOrDefault(); // tek bir nesne getirecek

                // yoksa not found ile geri döndük
                if (entity is null)
                    return NotFound(); // 404

                // check id sorun yoksa id e bak gelen id ile parametre id 

                if (id != book.Id)
                {
                    return BadRequest(); // 400
                }

                //_context.Books.Remove(entity); burda ifadeyi silmiş oluyoruz buna ihtiyac yok efcoreda where ile nesne takip ediliyor
                //book.Id = entity.Id; id e de dokunmamıza gerek yok 
                //_context.Books.Add(book); gerek yok


                // burda bir map işlemine gerek var 
                // yeni degerleri sag tarafta olanlar
                // mecvut olanlarla değiştirmiş guncellemiş oluyoruz soldakiler
                entity.Title = book.Title;
                entity.Price = book.Price;

                // boylece entity varlıgı uzerındeki değişiklikleri izlediğimi ve onayladıgmı söylemiş olacagım
                // guncellemenin kalıcı olması için savechanges i kullandık
                _context.SaveChanges();
                return Ok(book);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _context
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();

                if (entity is null) return NotFound(new
                {
                    statusCode = 404,
                    message = $"Book with id : {id} could not found."
                }); // 404

                _context.Books.Remove(entity);
                _context.SaveChanges();
                return NoContent();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // jsonpatch paketini yukledik program.cs e tanıttık
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            try
            {
                // check entity
                var entity = _context
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();
                if (entity is null) return NotFound(); // 404

                bookPatch.ApplyTo(entity);
                _context.SaveChanges();

                return NoContent(); // 204
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

