var builder = WebApplication.CreateBuilder(args);

/*

normal þartlar altýnda bir configure ifadesi yazacaksak veya IoC kaydý yapacaksak eger
önce service kaydý alýrýz

builder uzerýnden logging diye bir alan tanýmý var buna gelince ILoggingBuilder ifadesini göruyoruz
yani loglama insa etmek uzere tanýmlanmýs bir interface yapýsý 
logging uzerýnden bir komut verebiliyoruz bu ne demek default olarak bunun kaydý var demekki 
cerceve bize bir log lama mekanizmasý veriyor .net framework cercevesi 
bundan dolayý IoC e kayýt yapmak zorunda kalmýyoruz

bunlar default olarak tanýmlanmýs olmasaydý bunlarý app uzerýnden cagýrýp çözmek zorunda kalacaktýk 

þimdi programý calýstýrýnca direk olarak log lar gelecek bunu görebiliriz

appsettingjson da ekleme yaptýk info larý console da göstermesin diye yazdýk 

microsoft infolarýnýn hepsini sildi productlarý sadece console a yazýyor

özet configure ifadelerini yazabiliyoruz log olarak appsetting de bunlarý paket paketin altýndaki sýnýf gibi duzenleme yapabiliyoruz

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
