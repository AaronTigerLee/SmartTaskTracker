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
            // If the API is hosted on the actual internet...
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton<ToDoService>();
            builder.Services.AddSingleton<ToDosViewModel>();

            builder.Services.AddTransient<EditToDoPage>();
            builder.Services.AddTransient<EditToDosViewModel>();
            builder.Services.AddTransient<AddToDoPage>();
            builder.Services.AddTransient<AddToDosViewModel>();


#endif

            return builder.Build();
        }
    }
}
