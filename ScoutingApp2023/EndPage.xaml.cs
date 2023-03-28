using System.Diagnostics;
using ScoutingApp2023.Components;

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
            message.Text = "Error: You haven't used the Autonomous and Teleop tabs yet!";
            message.IsVisible = true;
            return;
        }

        // Save data
        Count(MauiProgram.ViewModel.AutoStack.Children,
              out int autoHighCone,
              out int autoMidCone,
              out int autoLowCone,
              out int autoHighCube,
              out int autoMidCube,
              out int autoLowCube,
              out int autoCones,
              out int autoCubes);

        Count(MauiProgram.ViewModel.TeleopStack.Children,
              out int teleopHighCone,
              out int teleopMidCone,
              out int teleopLowCone,
              out int teleopHighCube,
              out int teleopMidCube,
              out int teleopLowCube,
              out int teleopCones,
              out int teleopCubes);

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
			ToggleButton button1 = (ToggleButton)flex.Children[0];
            button1.Enabled = false;
            ToggleButton button2 = (ToggleButton)flex.Children[1];
            button2.Enabled = false;
			CycleButton picker = (CycleButton)flex.Children[2];
            picker.State = BaseState.None;
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

    private static void Count(IList<IView> children, out int highCone, out int midCone, out int lowCone, out int highCube, out int midCube, out int lowCube, out int cones, out int cubes)
    {
        highCone = midCone = lowCone = highCube = midCube = lowCube = 0;
        foreach (FlexLayout flex in children)
        {
            ToggleButton button1 = (ToggleButton)flex.Children[0];
            ToggleButton button2 = (ToggleButton)flex.Children[1];
            CycleButton picker = (CycleButton)flex.Children[2];
            bool isCone = button1.ButtonType == "cone";
            if (button1.Enabled)
            {
                int i = isCone ? highCone++ : highCube++;
            }
            if (button2.Enabled)
            {
                int i2 = isCone ? midCone++ : midCube++;
            }
            if (picker.State == BaseState.Cone)
            {
                lowCone++;
            }
            else if (picker.State == BaseState.Cube)
            {
                lowCube++;
            }
        }

        cones = lowCone + midCone + highCone;
        cubes = lowCube + midCube + highCube;
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