var builder = WebApplication.CreateBuilder(args);

/*

normal �artlar alt�nda bir configure ifadesi yazacaksak veya IoC kayd� yapacaksak eger
�nce service kayd� al�r�z

builder uzer�nden logging diye bir alan tan�m� var buna gelince ILoggingBuilder ifadesini g�ruyoruz
yani loglama insa etmek uzere tan�mlanm�s bir interface yap�s� 
logging uzer�nden bir komut verebiliyoruz bu ne demek default olarak bunun kayd� var demekki 
cerceve bize bir log lama mekanizmas� veriyor .net framework cercevesi 
bundan dolay� IoC e kay�t yapmak zorunda kalm�yoruz

bunlar default olarak tan�mlanm�s olmasayd� bunlar� app uzer�nden cag�r�p ��zmek zorunda kalacakt�k 

�imdi program� cal�st�r�nca direk olarak log lar gelecek bunu g�rebiliriz

appsettingjson da ekleme yapt�k info lar� console da g�stermesin diye yazd�k 

microsoft infolar�n�n hepsini sildi productlar� sadece console a yaz�yor

�zet configure ifadelerini yazabiliyoruz log olarak appsetting de bunlar� paket paketin alt�ndaki s�n�f gibi duzenleme yapabiliyoruz

 */

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
