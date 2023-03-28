using Microsoft.Maui.Layouts;
using System.Diagnostics;

namespace ScoutingApp2023;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        BindingContext = MauiProgram.ViewModel;
        MauiProgram.ViewModel.TeamNumberEntry = teamNumberEntry;
        MauiProgram.ViewModel.ScouterNameEntry = scoutNameEntry;
        MauiProgram.ViewModel.SidePicker = side;
        MauiProgram.ViewModel.MatchNumberEntry = matchNumberEntry;
    }

    private void OnNavigate(object sender, NavigatedToEventArgs e)
    {
    }

    private void OnAlliancePickerSelectedIndexChanged(object sender, EventArgs e)
    {
        Picker picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex < 0)
        {
            MauiProgram.ViewModel.FlowDirection = FlexDirection.Row;
            return;
        }
        string item = picker.Items[selectedIndex];
        if (item == "Right")
        {
            MauiProgram.ViewModel.FlowDirection = FlexDirection.RowReverse;
            return;
        }
        MauiProgram.ViewModel.FlowDirection = FlexDirection.Row;
    }
}

