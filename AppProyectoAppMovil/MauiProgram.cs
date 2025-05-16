using Microsoft.Extensions.Logging;
using AppProyectoAppMovil.Services;
using AppProyectoAppMovil.ViewModels;
using AppProyectoAppMovil.Views;
using ZXing.Net.Maui.Controls;
using ZXing.Net.Maui;
namespace AppProyectoAppMovil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseBarcodeReader() // Configuración para ZXing (lector de códigos)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureMauiHandlers(handlers =>
                {
                         handlers.AddHandler<CameraBarcodeReaderView, CameraBarcodeReaderViewHandler>();
                });

#if DEBUG
            builder.Logging.AddDebug(); // Habilitar logging en modo debug
#endif

            // Registro de servicios y ViewModels
            ConfigureServices(builder.Services);

            return builder.Build();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Servicios
            services.AddSingleton<DatabaseService>();

            // ViewModels
            services.AddTransient<ScanViewModel>();
            services.AddTransient<ResultViewModel>();

            // Vistas (Pages)
            services.AddTransient<ScanPage>();
            services.AddTransient<ResultPage>();
            services.AddLogging(configure => configure.AddConsole());
        }
    }
}