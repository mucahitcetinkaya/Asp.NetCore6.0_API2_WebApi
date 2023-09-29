using bookDemo.Models;

namespace bookDemo.Data
{
    public static class ApplicationContext
    {
        public static List<Book> Books { get; set; }
        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book(){Id = 1, Title = "Hacivat ve Karagöz", Price = 50},
                new Book(){Id = 2, Title = "Mesnevi", Price = 100},
                new Book(){Id = 1, Title = "Dede Korkut", Price = 150},
            };
        }
    }
}
