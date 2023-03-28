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

    public static void OnConeClick(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        button.SetValue(MauiProgram.ButtonEnabled, !(bool)button.GetValue(MauiProgram.ButtonEnabled));
        if ((bool)button.GetValue(MauiProgram.ButtonEnabled))
        {
            button.Source = "cone.png";
        }
        else
        {
            button.Source = "graycone.png";
        }
    }
    public static void OnCubeClick(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        button.SetValue(MauiProgram.ButtonEnabled, !(bool)button.GetValue(MauiProgram.ButtonEnabled));
        if ((bool)button.GetValue(MauiProgram.ButtonEnabled))
        {
            button.Source = "cube.png";
        }
        else
        {
            button.Source = "graycube.png";
        }
    }

    public static void OnBaseClick(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        if ((BaseState)button.GetValue(MauiProgram.BaseState) == ScoutingApp2023.BaseState.Cone)
        {
            button.SetValue(MauiProgram.BaseState, ScoutingApp2023.BaseState.None);
        }
        else
        {
            button.SetValue(MauiProgram.BaseState, (BaseState)button.GetValue(MauiProgram.BaseState) + 1);
        }

        switch ((BaseState)button.GetValue(MauiProgram.BaseState))
        {
            case ScoutingApp2023.BaseState.None:
                button.Source = "cube_cone_cycle_none.png";
                break;
            case ScoutingApp2023.BaseState.Cube:
                button.Source = "cube_cone_cycle_cube.png";
                break;
            case ScoutingApp2023.BaseState.Cone:
                button.Source = "cube_cone_cycle_cone.png";
                break;
        }
    }
}
