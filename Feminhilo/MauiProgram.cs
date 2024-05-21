using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Refit;
using Feminhilo.Services;
using Feminhilo.ViewModels;
using Feminhilo.Pages;


#if ANDROID
using Xamarin.Android.Net;
using Java.Security.Cert;
using AndroidX.ConstraintLayout.Core.Widgets;
using System.Net.Security;
#endif
namespace Feminhilo
{
    public static class MauiProgram
    {

        private static readonly string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android
        ? "https://v0l0qcpd-7034.euw.devtunnels.ms"  // Use your actual dev tunnel URL
        : "https://localhost:7034";
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<HomeViewModel>()
                            .AddSingleton<HomePage>();

            builder.Services.AddSingleton<CartViewModel>();
            builder.Services.AddTransient<CartPage>();


            ConfigurationRefit(builder.Services);
            return builder.Build();
        }

        private static void ConfigurationRefit(IServiceCollection services)
        {
            var refitSettings = new RefitSettings
            {
                HttpMessageHandlerFactory = () =>
                {
#if ANDROID
                    return new AndroidMessageHandler
                    {

                        ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
                        {
                            return certificate?.Issuer == "CN=localhost" || sslPolicyErrors == SslPolicyErrors.None;
                            
                        }
                    };
#endif
                    return null;
                }
            };
            services.AddRefitClient<IItemsApi>(refitSettings).ConfigureHttpClient(SetHttpClient);

               

         static void SetHttpClient(HttpClient httpClient)
        {
            var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "https://10.0.2.2:7034"  // Android emulator uses 10.0.2.2 to connect to localhost
                : BaseAddress;  // For other platforms, use the base address

            httpClient.BaseAddress = new Uri(baseUrl);
        }


    }
    }
}
