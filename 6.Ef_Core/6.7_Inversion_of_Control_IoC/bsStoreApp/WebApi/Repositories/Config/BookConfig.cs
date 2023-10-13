using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Repositories.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Karagöz ve Hacivat", Price = 50 },
                new Book { Id = 2, Title = "Mesnevi", Price = 100 },
                new Book { Id = 3, Title = "Devlet", Price = 150 }
            );
        }
    }
}

/*

hasdata dan sonra parantez içindeki tooltype ozelliklerini okursan eger params ifadesi yazıyor
her new book yazıp virgül ile diger new book eklemeye dizi gibi olanak saglayan params oluyor
istediğin kadar kitap tanımı yapabilirsin

dataları yukledik ama mig aldıgında yuklediğin datalar gelmez boş gözukuyor
bos gozukmemesi için baglantı kurmamız lazım bookcongif ile context arasında 
repositorycontext e gidelim

*/

