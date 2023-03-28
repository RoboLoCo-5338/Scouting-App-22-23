using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace ScoutingApp2023;

public partial class EndPage : ContentPage
{
	public EndPage()
	{
		InitializeComponent();
	}

	private void OnSubmit(object sender, EventArgs e)
	{
        // There is no data if you haven't even navigated to the other tabs yet...
        if (MauiProgram.ViewModel.TeleopStack.Children == null || MauiProgram.ViewModel.AutoStack.Children == null)
        {
            message.Text = "Error: You haven't used the Autonomous and Telop tabs yet!";
            message.IsVisible = true;
            return;
        }

        // Save data
        int autoCones = 0;
		int autoCubes = 0;
		int teleopCones = 0;
		int teleopCubes = 0;
        int autoHighCone = 0;
        int autoHighCube = 0;
        int autoMidCone = 0;
        int autoMidCube = 0;
        int autoLowCone = 0;
        int autoLowCube = 0;
        int teleopHighCone = 0;
        int teleopHighCube = 0;
        int teleopMidCone = 0;
        int teleopMidCube = 0;
        int teleopLowCone = 0;
        int teleopLowCube = 0;
        foreach (FlexLayout flex in MauiProgram.ViewModel.AutoStack.Children)
		{
            ImageButton button1 = (ImageButton)flex.Children[0];
            ImageButton button2 = (ImageButton)flex.Children[1];
            ImageButton picker = (ImageButton)flex.Children[2];
            bool isCone = button1.Source.ToString().Contains("cone");
			if ((bool)button1.GetValue(MauiProgram.ButtonEnabled))
			{
                int i = isCone ? autoHighCone++ : autoHighCube++;
            }
			if ((bool)button2.GetValue(MauiProgram.ButtonEnabled))
			{
                int i2 = isCone ? autoMidCone++ : autoMidCube++;
            }
			if ((BaseState)picker.GetValue(MauiProgram.BaseState) == BaseState.Cone)
			{
				autoLowCone++;
			}
            else if ((BaseState)picker.GetValue(MauiProgram.BaseState) == BaseState.Cube)
            {
                autoLowCube++;
            }
        }
        autoCones = autoLowCone + autoMidCone + autoHighCone;
        autoCubes = autoLowCube + autoMidCube + autoHighCube;
        foreach (FlexLayout flex in MauiProgram.ViewModel.TeleopStack.Children)
        {
            ImageButton button1 = (ImageButton)flex.Children[0];
            ImageButton button2 = (ImageButton)flex.Children[1];
            ImageButton picker = (ImageButton)flex.Children[2];
            bool isCone = button1.Source.ToString().Contains("cone");
            if ((bool)button1.GetValue(MauiProgram.ButtonEnabled))
            {
                int i = isCone ? teleopHighCone++ : teleopHighCube++;
            }
            if ((bool)button2.GetValue(MauiProgram.ButtonEnabled))
            {
                int i2 = isCone ? teleopMidCone++ : teleopMidCube++;
            }
            if ((BaseState)picker.GetValue(MauiProgram.BaseState) == BaseState.Cone)
            {
                teleopLowCone++;
            }
            else if ((BaseState)picker.GetValue(MauiProgram.BaseState) == BaseState.Cube)
            {
                teleopLowCube++;
            }
        }
        teleopCones = teleopLowCone + teleopMidCone + teleopHighCone;
        teleopCubes = teleopLowCube + teleopMidCube + teleopHighCube;
        int autoPoints = 6 * autoHighCone + 6 * autoHighCube + 4 * autoMidCone + 4 * autoMidCube + 3 * autoLowCone + 3 * autoLowCube;
        int teleopPoints = 5 * teleopHighCone + 5 * teleopHighCube + 3 * teleopMidCone + 3 * teleopMidCube + 2 * teleopLowCone + 2 * teleopLowCube;
        if (MauiProgram.ViewModel.AutoMobility.IsChecked)
        {
            autoPoints += 3;
        }
        if (MauiProgram.ViewModel.AutoDocked.IsChecked)
        {
            autoPoints += 8;
        }
        if (MauiProgram.ViewModel.AutoEngaged.IsChecked && MauiProgram.ViewModel.AutoDocked.IsChecked)
        {
            autoPoints += 4;
        }
        else if (MauiProgram.ViewModel.AutoEngaged.IsChecked)
        {
            autoPoints += 12;
        }
        if (MauiProgram.ViewModel.TeleopParked.IsChecked)
        {
            teleopPoints += 2;
        }
        if (MauiProgram.ViewModel.TeleopDocked.IsChecked)
        {
            teleopPoints += 6;
        }
        if (MauiProgram.ViewModel.TeleopEngaged.IsChecked && MauiProgram.ViewModel.TeleopDocked.IsChecked)
        {
            teleopPoints += 4;
        }
        else if (MauiProgram.ViewModel.TeleopEngaged.IsChecked)
        {
            teleopPoints += 10;
        }
        int points = autoPoints + teleopPoints;
        List<string> data = new()
        {
            MauiProgram.ViewModel.TeamNumberEntry.Text,
            MauiProgram.ViewModel.ScouterNameEntry.Text,
            MauiProgram.ViewModel.MatchNumberEntry.Text,
            MauiProgram.ViewModel.AutoMobility.IsChecked.ToString().ToUpper(),
            MauiProgram.ViewModel.AutoDocked.IsChecked.ToString().ToUpper(),
            MauiProgram.ViewModel.AutoEngaged.IsChecked.ToString().ToUpper(),
            autoCones.ToString(),
            autoCubes.ToString(),
            MauiProgram.ViewModel.TeleopParked.IsChecked.ToString().ToUpper(),
            MauiProgram.ViewModel.TeleopDocked.IsChecked.ToString().ToUpper(),
            MauiProgram.ViewModel.TeleopEngaged.IsChecked.ToString().ToUpper(),
            teleopCones.ToString(),
            teleopCubes.ToString(),
            autoHighCone.ToString(),
            autoHighCube.ToString(),
            autoMidCone.ToString(),
            autoMidCube.ToString(),
            autoLowCone.ToString(),
            autoLowCube.ToString(),
            teleopHighCone.ToString(),
            teleopHighCube.ToString(),
            teleopMidCone.ToString(),
            teleopMidCube.ToString(),
            teleopLowCone.ToString(),
            teleopLowCube.ToString(),
            autoPoints.ToString(),
            teleopPoints.ToString(),
            points.ToString(),
            defense.IsChecked.ToString().ToUpper(),
            noMove.IsChecked.ToString().ToUpper(),
            $"\"{comments.Text}\""
        };
        MauiProgram.Data.Add(data);
        // Clear elements
        MauiProgram.ViewModel.TeamNumberEntry.Text = string.Empty;
		MauiProgram.ViewModel.ScouterNameEntry.Text = string.Empty;
        MauiProgram.ViewModel.SidePicker.SelectedIndex = -1;
		MauiProgram.ViewModel.MatchNumberEntry.Text = string.Empty;

		foreach (FlexLayout flex in Enumerable.Concat(MauiProgram.ViewModel.AutoStack.Children, MauiProgram.ViewModel.TeleopStack.Children))
		{
			ImageButton button1 = (ImageButton)flex.Children[0];
			button1.SetValue(MauiProgram.ButtonEnabled, false);
            ImageButton button2 = (ImageButton)flex.Children[1];
            button2.SetValue(MauiProgram.ButtonEnabled, false);
			if (button1.Source.ToString().Contains("cone"))
			{
                button1.Source = "graycone.png";
                button2.Source = "graycone.png";
            }
			else
			{
                button1.Source = "graycube.png";
                button2.Source = "graycube.png";
            }
			ImageButton picker = (ImageButton)flex.Children[2];
            picker.Source = "cube_cone_cycle_none.png";
            picker.SetValue(MauiProgram.BaseState, BaseState.None);
        }
		MauiProgram.ViewModel.AutoMobility.IsChecked = false;
		MauiProgram.ViewModel.AutoDocked.IsChecked = false;
		MauiProgram.ViewModel.AutoEngaged.IsChecked = false;
        MauiProgram.ViewModel.TeleopParked.IsChecked = false;
        MauiProgram.ViewModel.TeleopDocked.IsChecked = false;
        MauiProgram.ViewModel.TeleopEngaged.IsChecked = false;
		defense.IsChecked = false;
		noMove.IsChecked = false;
		comments.Text = string.Empty;
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OnExport(object sender, EventArgs e)
    {
#if ANDROID
        string targetDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDcim).AbsoluteFile.Path;
#else
        string targetDirectory = Environment.CurrentDirectory;
#endif
        string targetFileName = $"scouting_data-{DateTime.Today:yyyy-mm-dd}T{DateTime.Now:hh-mm}.csv";
        string targetFile = Path.Combine(targetDirectory, targetFileName);
        if (!Directory.Exists(targetDirectory)) 
        {
            Directory.CreateDirectory(targetDirectory);
        }
        using FileStream outputStream = File.OpenWrite(targetFile);
        using StreamWriter streamWriter = new(outputStream);
        string text = "teamNumber,scouterName,matchNumber,autoMobility,autoDock,autoEngage,autoCone,autoCube,teleopPark,teleopDock,teleopEngage,teleopCone,teleopCube,autoHighCone,autoHighCube,autoMidCone,autoMidCube,autoLowCone,autoLowCube,teleopHighCone,teleopHighCube,teleopMidCone,teleopMidCube,teleopLowCone,teleopLowCube,Auto Points,Teleop Points,points,Defense,Did not move,comments\n";
        foreach (List<string> data in MauiProgram.Data)
        {
            foreach (string entry in data)
            {
                text += entry + ",";
            }
            text = text.Remove(text.Length - 1, 1);
            text += "\n";
        }

        streamWriter.WriteAsync(text);
        Clipboard.Default.SetTextAsync(targetDirectory);
        message.Text = $"Succesfully exported data to: {targetFile} (Path copied to clipboard)";
        message.IsVisible = true;
        MauiProgram.Data.Clear();
    }
}