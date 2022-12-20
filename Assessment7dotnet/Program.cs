using Microsoft.EntityFrameworkCore;
using Assessment7dotnet.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<Week7dotnetContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

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
    "ByVehicle",
    "Claims/ByVehicle/{vin}",
    new { Controller = "Claims", Action = "ByVehicle" });
app.MapControllerRoute(
   "ByOwner" ,
   "Vehicles/ByOwner/{drivelicense}",
   new { Controller = "Vehicles", action = "ByOwner" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
