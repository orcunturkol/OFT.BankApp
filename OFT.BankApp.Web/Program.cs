using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using OFT.BankApp.Web.Data.Context;
using OFT.BankApp.Web.Data.Interfaces;
using OFT.BankApp.Web.Data.Repositories;
using OFT.BankApp.Web.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BankContext>(opt =>
{
    opt.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BankDB;Trusted_Connection=True;");
}); 

builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountMapper, AccountMapper>();

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


