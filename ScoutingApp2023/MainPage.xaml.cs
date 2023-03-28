using Microsoft.Maui.Layouts;
using System.Diagnostics;

namespace ScoutingApp2023;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        MauiProgram.ViewModel.TeamNumberEntry = teamNumberEntry;
        MauiProgram.ViewModel.ScouterNameEntry = scoutNameEntry;
        MauiProgram.ViewModel.SidePicker = side;
        MauiProgram.ViewModel.MatchNumberEntry = matchNumberEntry;
    }
}

