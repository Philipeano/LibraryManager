using LibraryManager.Data;
using LibraryManager.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("LibraryManagerConnStr");
builder.Services.AddDbContext<LibraryManagerContext>(options => options.UseSqlServer(connectionString));

/* Use any of the 3 service lifetimes to register your user-define services
 *     AddSingleton - Creates one instance of the service and uses it throughout the lifetime of the app, for all requests
 *     AddScoped - Creates a new instance of the service and uses it throughout a particular request/response cycle
 *     AddTransient - Creates a new instance each time the service is requested, whether within the same request or not.
 */

builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
