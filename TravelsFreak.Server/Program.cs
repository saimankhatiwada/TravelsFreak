using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using TravelsFreak.Data.DatabaseContext;
using TravelsFreak.Repository;
using TravelsFreak.Repository.IRepository;
using TravelsFreak.Server.Service.IService;
using TravelsFreak.Server.Service;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzU1Nzk2QDMyMzAyZTMzMmUzMEJsM1RGTUZjVm5RS3A4dGRaSEVzaVh0czNkVjFEbktsMEgrb0dtYUpOSzA9");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDestinationsRepository, DestinationsRepository>();
builder.Services.AddScoped<ITourPackageRepository, TourPackageRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IFileUpload, FileUpload>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
