var builder = WebApplication.CreateBuilder(args);

// Service (Container)

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// launchsetting den geldik 2.5
// eger development moddaysa uygyulama swagger i kullansýn yoksa kullanmasýn 
// IIS dem calýstýrýnca uygulmaayý hata veriyor production mod yani 
// swagger yazýnca yine yanýt alamýyorum kapattýk launchurl kýsmýný 
// ama home a gittiðimiz de sadece data geliyor 
// böyle yaparak development mod ile production modunu ayýrmýs olduk 
// veri tabaný baglantýsý log lama ifadeleri configrasyomun tamanýný deðiþtirebilirdim 
// ornegýn development moddayken sqlite a göre calýs production oldugunda mssql e göre calýs gibi
// notlara dön


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// swagger calýssýn diye bu metotlarý cagýrdýk

//app.UseSwagger();
//app.UseSwaggerUI();

// mapcontroller olmadan uygulama calýstýgýnda exetuce ettiðimiz de 404 error verdi cevap gelmedi yani
// mapcontroller yazýlýnca calýstýrýnca geri dönus alabildik

app.MapControllers();

app.Run();
