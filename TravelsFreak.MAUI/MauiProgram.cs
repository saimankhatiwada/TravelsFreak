using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TravelFreak.Client.Service;
using TravelsFreak.MAUI.Service;
using TravelsFreak.MAUI.Service.IService;

namespace TravelsFreak.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7228") });
            builder.Services.AddScoped<ITourPackageService, TourPackageService>();
            builder.Services.AddScoped<IBlogService, BlogService>();

            return builder.Build();
        }
    }
}