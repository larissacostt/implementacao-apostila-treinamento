using capitulo01.Data;
using Microsoft.EntityFrameworkCore;

//cria o objeto que vai montar a aplicação
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<IESContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IESConnection"))); //procura a conexao chamada

var app = builder.Build(); //pega a configuração e monta a aplicação

if (!app.Environment.IsDevelopment())
{
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
app.Run();

    

