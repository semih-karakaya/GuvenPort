using guvenport.Models;
using Microsoft.EntityFrameworkCore;
using guvenport.Models.Interface;
using guvenport.Services;
using guvenport.Services.IoC;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

builder.Services.AddDbContext<CustomApplicationDbContext>(options =>
// Register services before building the app
builder.Services.AddDbContext<CustomApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))));
builder.Services.AddHttpClient<AuthenticationService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:44384");
});
builder.Services.AddHttpClient<DashboardService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:44384");
});builder.Services.AddHttpClient<EmployeeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:44384");
});
builder.Services.AddScopedService();
builder.Services.AddHttpContextAccessor(); // <-- Add this line


// Build the app after all services are registered
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

app.MapControllers();
app.MapRazorPages();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
