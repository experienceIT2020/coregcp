using CoreGCP.Data;
using CoreGCP.Services;
using CoreGCP.Utils.ConfigOptions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container...
builder.Services.AddControllersWithViews();
builder.Services.Configure<GCSConfigOptions>(builder.Configuration);
builder.Services.AddSingleton<ICloudStorageService, CloudStorageService>();

builder.Services.AddDbContext<GcpCoreContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("gcpCoreContext") ?? throw new InvalidOperationException("Connection string 'gcpCoreContext' not found.")));

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
