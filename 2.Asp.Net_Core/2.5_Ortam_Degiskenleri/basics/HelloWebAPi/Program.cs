var builder = WebApplication.CreateBuilder(args);

// Service (Container)

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// launchsetting den geldik 2.5
// eger development moddaysa uygyulama swagger i kullans�n yoksa kullanmas�n 
// IIS dem cal�st�r�nca uygulmaay� hata veriyor production mod yani 
// swagger yaz�nca yine yan�t alam�yorum kapatt�k launchurl k�sm�n� 
// ama home a gitti�imiz de sadece data geliyor 
// b�yle yaparak development mod ile production modunu ay�rm�s olduk 
// veri taban� baglant�s� log lama ifadeleri configrasyomun taman�n� de�i�tirebilirdim 
// orneg�n development moddayken sqlite a g�re cal�s production oldugunda mssql e g�re cal�s gibi
// notlara d�n


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// swagger cal�ss�n diye bu metotlar� cag�rd�k

//app.UseSwagger();
//app.UseSwaggerUI();

// mapcontroller olmadan uygulama cal�st�g�nda exetuce etti�imiz de 404 error verdi cevap gelmedi yani
// mapcontroller yaz�l�nca cal�st�r�nca geri d�nus alabildik

app.MapControllers();

app.Run();
