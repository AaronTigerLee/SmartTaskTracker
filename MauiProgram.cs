using Microsoft.Extensions.Logging;
using SmartTaskTracker.Service;
using SmartTaskTracker.ViewModel;

namespace SmartTaskTracker
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<ToDoService>();
            builder.Services.AddSingleton<ToDosViewModel>();


#endif

            return builder.Build();
        }
    }
}
