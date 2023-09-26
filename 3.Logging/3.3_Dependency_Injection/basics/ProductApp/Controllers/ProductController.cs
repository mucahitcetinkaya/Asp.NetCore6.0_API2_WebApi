using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    // route vererek yolunu belli etmiş oluyoruz route yapısına dikkat et dogru yazmazsan eger map hatası alırsın 

    /*
    
    3.3 notları
    bir ifade readonly ise degeri ctor ve tanımlandıgı yerde verilebilir baska bir yerde atanama yapılamaz sadece okunabilir
    sadece okunabilir olan bu ifadenin değerini sadece 1 kez set edebiliyoruz
    tanımlandıgı yer yazıldıgı yer oluyor oraya baktıgımızda her hangi bir deger ataması yok 
    buraya bir ifade verilecek ve newlenecek biz baska bir işlem yapmayacagız yerleşik olan gelen IOC kaydını kullanıyor olacagız
    IOC kaydı havuz kaydı oluyor 
    bu yapıya DI dependency injection diyoruz

    private readonly diyerek ILogger interface ini cagırdık bu interface i implement eden baska sınıflarda olabilir
    biz su anda ILogger a ne geleceğini bilmiyoruz ama sunu biliyoruz ne geleceği ctor asamasında belli olacak
    productcontroller new lendiği anda logger ifadesinin concrete soyut hali elimde olmus olacak 

    */

    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = new List<Product>()
            {
                new Product { Id = 1, ProductName = "Computer"},
                new Product { Id = 2, ProductName = "Keybord"},
                new Product { Id = 3, ProductName = "Mouse"}
            };

            /*log lama yani console da bilgi geçiyoruz istenilen calıstı veya cagrıldı gibi*/

            _logger.LogInformation("GetAllProducts action has been called.");
            return Ok(products);
        }
    }
}
