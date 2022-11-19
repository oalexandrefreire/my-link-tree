using Data.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var MySqlConnectionStringFromJson = builder.Configuration.GetValue<string>("env:MySqlConnectionString");
builder.Services.AddDbContextPool<LinksContext>(options =>
    options.UseMySql(MySqlConnectionStringFromJson, ServerVersion.AutoDetect(MySqlConnectionStringFromJson)));

var cultureInfo = new CultureInfo("pt-BR");
cultureInfo.NumberFormat.CurrencySymbol = "R$";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


var app = builder.Build();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

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
app.MapControllerRoute(name: "default", pattern: "{controller=Links}/{action=Index}/{username?}");
app.Run();