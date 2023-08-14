using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MAUI_CoolDudes
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            var migrationAssembly = typeof(CoolDudeDbContext).Assembly.GetName().Name;
            builder.Services.AddDbContext<CoolDudeDbContext>(opts =>
            {
                var dbPath = Path.Combine(FileSystem.AppDataDirectory, "database.db3");
                opts.UseSqlite($"Filename={dbPath}", x => x.MigrationsAssembly(migrationAssembly));
            });

            builder.Services.AddSingleton<AppState>();
            builder.Services.AddSingleton<DataService>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPageViewModel>();

            return builder.Build();
        }
    }
}