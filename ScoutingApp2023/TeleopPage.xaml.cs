using System.Runtime.InteropServices.ObjectiveC;

namespace ScoutingApp2023;

public partial class TeleopPage : ContentPage
{
    public TeleopPage()
	{
		InitializeComponent();
        NavigatedTo += OnNavigated;
        MauiProgram.ViewModel.TeleopStack = stack2;
        MauiProgram.ViewModel.TeleopParked = parked;
        MauiProgram.ViewModel.TeleopDocked = docked;
        MauiProgram.ViewModel.TeleopEngaged = engaged;
	}

    private void OnNavigated(object sender, NavigatedToEventArgs e)
    {
        foreach (FlexLayout flex in stack2.Children)
        {
            flex.Direction = MauiProgram.ViewModel.FlowDirection;
        }
    }

    private void OnConeClick(object sender, EventArgs e) => MauiProgram.OnConeClick(sender, e);
    private void OnCubeClick(object sender, EventArgs e) => MauiProgram.OnCubeClick(sender, e);
    private void OnBaseClick(object sender, EventArgs e) => MauiProgram.OnBaseClick(sender, e);
}