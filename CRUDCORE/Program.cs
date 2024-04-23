using CRUDCORE.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//var secret = builder.Configuration["ConexionStringLocalDB"];
builder.Services.AddDbContext<DbcrudcoreContext>(options => options.UseSqlServer(builder.Configuration["ConexionStringLocalDB"]));
//Console.WriteLine(secret);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
