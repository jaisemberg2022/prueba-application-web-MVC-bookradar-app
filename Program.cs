using BookRadarApp;
using BookRadarApp.Application.Books;
using BookRadarApp.Application.Interfaces.Books;
using BookRadarApp.Application.Interfaces.SearchLog;
using BookRadarApp.Application.SearchLog;
using BookRadarApp.Domain.Books;
using BookRadarApp.Domain.Interfaces.Books;
using BookRadarApp.Domain.Interfaces.SearchLog;
using BookRadarApp.Domain.SearchLog;
using BookRadarApp.Infraestructure.Repository.Books;
using BookRadarApp.Infraestructure.Repository.Interfaces.Books;
using BookRadarApp.Infraestructure.Repository.Interfaces.SearchLog;
using BookRadarApp.Infraestructure.Repository.SearchLog;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppSettingsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppSettingsDbContext"));
});

builder.Services.AddHttpClient<IApiBookLibraryRepository, ApiBookLibraryRepository>();

//Repositorios
builder.Services.AddScoped<IApiBookLibraryRepository, ApiBookLibraryRepository>();
builder.Services.AddScoped<ISearchLogRepository, SearchLogRepository>();
//Dominios
builder.Services.AddScoped<IApiBookLibraryDomain, ApiBookLibraryDomain>();
builder.Services.AddScoped<ISearchLogDomain, SearchLogDomain>();
//Aplicaciones
builder.Services.AddScoped<IApiBookLibraryApplication, ApiBookLibraryApplication>();
builder.Services.AddScoped<ISearchLogApplication, SearchLogApplication>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Buscar}/{id?}");

app.Run();
