using Microsoft.Extensions.Logging;

namespace ScoutingApp2023;

public enum BaseState
{
	None = 0,
	Cube = 1,
	Cone = 2
}

public static class MauiProgram
{
    public static readonly BindableProperty ButtonEnabled = BindableProperty.CreateAttached("ButtonEnabled", typeof(bool), typeof(ImageButton), false);
    public static readonly BindableProperty BaseState = BindableProperty.CreateAttached("BaseState", typeof(BaseState), typeof(ImageButton), ScoutingApp2023.BaseState.None);
    public static MainViewModel ViewModel = new MainViewModel();
	public static List<List<string>> Data = new();
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

		return builder.Build();
	}
}
