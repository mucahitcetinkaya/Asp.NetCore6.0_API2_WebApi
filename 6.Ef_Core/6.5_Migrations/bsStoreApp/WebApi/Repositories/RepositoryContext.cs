using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class RepositoryContext : DbContext
    {

        public RepositoryContext(DbContextOptions options) : base(options)
        {
            

        }

        public DbSet<Book> Books { get; set; }
    }
}

// appsetting dosyasına gidelim 


//////////////////////////////////////////////////////////////
//namespace WebApi.Repositories
//{
//    public class RepositoryContext : DbContext
//    {

//        public DbSet<Book> Books { get; set; }
//    }
//}
