using Microsoft.AspNetCore.Mvc;
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
            var books = _context.Books.ToList();
            return Ok(books);
        }
    }
}

// DI ile almamızın sebebleri tek bir yerde yazıp ordan baglanmak 
// eger böyle DI ile yazmasaydık ctor içine yeni bir nesne olusturup baglantı isimlerini vs hep burda yazmak zorunda kalırdık
// boyle yazarak ayarlını bir yerde yaptık sadece burda cagırmıs oluyoruz