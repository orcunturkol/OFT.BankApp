using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using OFT.BankApp.Web.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BankContext>(opt =>
{
    opt.UseSqlServer("server=(localdb)\\mssqllocaldb; database = BankDb; Integrated Security=true;");
}); 
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider (Path.Combine
    (Directory.GetCurrentDirectory(), "node_modules")), 
    RequestPath = "/node_modules"
}); 

app.MapDefaultControllerRoute();

app.Run();


