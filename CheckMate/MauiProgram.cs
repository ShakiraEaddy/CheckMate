using CheckMate.Data;
using CheckMate.View;
using CheckMate.ViewModels;
using Microsoft.Extensions.Logging;

namespace CheckMate
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
#endif
            builder.Services.AddSingleton<DatabaseContext>();
            builder.Services.AddSingleton<TasksViewModel>();
            // May need to change to CreateTaskPage (whether that is the view model class or an adjacent one)
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}