using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Repositories.Config;

namespace WebApi.Repositories
{
    public class RepositoryContext : DbContext
    {

        public RepositoryContext(DbContextOptions options) : base(options)
        {
            

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}


/*

6.6 type configurations notları  
 protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration (new BookConfig());
        }

bunu eklediğimiz bookconfig ile ilişkilendirmek için yazdık bunu yazmazsak eger mig aldıgında bos gelir tablo
bunu ekleyerek içeriğini doldurmus oluyoruz
tip configrasyon alanını bildirmiş oluyoruz
override anahtar kelimesi kalıtım ile miras aldıgımız bir metodu geçersiz kıldıgımızı belirtiyoruz
bunu daha oncelikli yap demek oluyor 
kalıtımla miras almak derken dbcontext uzerınden kullanıyoruz paket yukledik onun metodunu ozelleştirmek gibi düşün
 
*/






///////////////
// appsetting dosyasına gidelim 


//////////////////////////////////////////////////////////////
//namespace WebApi.Repositories
//{
//    public class RepositoryContext : DbContext
//    {

//        public DbSet<Book> Books { get; set; }
//    }
//}
