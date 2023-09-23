var builder = WebApplication.CreateBuilder(args);

// Service (Container)

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// swagger cal�ss�n diye bu metotlar� cag�rd�k

app.UseSwagger();
app.UseSwaggerUI();

// mapcontroller olmadan uygulama cal�st�g�nda exetuce etti�imiz de 404 error verdi cevap gelmedi yani
// mapcontroller yaz�l�nca cal�st�r�nca geri d�nus alabildik

app.MapControllers();

app.Run();
