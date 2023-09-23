var builder = WebApplication.CreateBuilder(args);

// Service (Container)

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// swagger calýssýn diye bu metotlarý cagýrdýk

app.UseSwagger();
app.UseSwaggerUI();

// mapcontroller olmadan uygulama calýstýgýnda exetuce ettiðimiz de 404 error verdi cevap gelmedi yani
// mapcontroller yazýlýnca calýstýrýnca geri dönus alabildik

app.MapControllers();

app.Run();
