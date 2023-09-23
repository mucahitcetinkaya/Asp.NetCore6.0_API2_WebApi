using HelloWebAPi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWebAPi.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {

        /*
        böyle yazdıgımızda 404 döndü bunu sebebi home ifadesini çözemedi
        program.cs e mapcontrollers yazınca 200 döndü

        models e geçmeden önce restfullapi nin bize herhangi bir dosya formatı dayatmadıgını belirtmek istiyorum
        içerik normal yazı olarak geliyor text yani 

        */

        //[HttpGet]
        //public string GetMessage()
        //{
        //    return "Hello ASP.NET Core Web API";
        //}


        /*
        
        böyle yazıp calıstırgımız da calısıyor
        body sinde status code 200
        message kısmında içerik yazıyor
        ve otomatik olarak json olarak gönderiyor
        calıstıgımız sınıf apicontroller oldugu için otomatik olarak json a ceviriyor
         
        */
        //[HttpGet]
        //public ResponseModel GetMessage()
        //{
        //    return new ResponseModel()
        //    {
        //        HttpStatus = 200,
        //        Message = "Hello ASP.NET Core Web API"
        //    };
        //}


        /*
        
        ResponseModel ile class ile cagırmak yerine IActionsResult olarak interface yapısını kullanmak daha iyi olur
         
         
        */


        [HttpGet]
        public IActionResult GetMessage()
        {
            var result = new ResponseModel()
            {
                HttpStatus = 200,
                Message = "Hello ASP.NET Core Web API"
            };

            return Ok(result);
        }
    }
}
