namespace SnakrMauiApp;

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
				fonts.AddFont("FontAwesome6FreeBrands.otf", "FontAwesomeBrands");
				fonts.AddFont("FontAwesome6FreeRegular.otf", "FontAwesomeRegular");
				fonts.AddFont("FontAwesome6FreeSolid.otf", "FontAwesomeSolid");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddTransient<SampleDataService>();
        builder.Services.AddTransient<SnakrDataService>();

        
        builder.Services.AddTransient<UsersDetailViewModel>();
		builder.Services.AddTransient<UsersDetailPage>();

        builder.Services.AddSingleton<UsersViewModel>();
        builder.Services.AddSingleton<UsersPage>();
        
		builder.Services.AddSingleton<MasterUsersViewModel>();
        builder.Services.AddSingleton<MasterUsersPage>();

        return builder.Build();
	}
}
