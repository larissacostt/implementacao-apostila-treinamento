using   capitulo01.Data;
using   Microsoft.EntityFrameworkCore;

//cria o objeto que vai montar a aplicação
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<IESContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IESConnection"))); //procura a conexao chamada

var app = builder.Build(); //pega a configuração e monta a aplicação

using (var scope = app.Services.CreateScope()) //cria o ambiente pra pegar o serviços config
{
    var services = scope.ServiceProvider; //objeto que fornece os serviços registrados
    try
    {
        var context = services.GetRequiredService<IESContext>();
        IESDbInitializer.Initialize(context);
    } catch (Exception ex)
    {
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger("Programs");
        logger.LogError(ex, "Um erro ocorreu ao popular no banco de dados.");

    }

    if (!app.Environment.IsDevelopment()) {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
                name: "default",
                pattern: "{Controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
}
    app.Run();
   

