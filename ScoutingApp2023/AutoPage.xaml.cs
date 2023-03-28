namespace ScoutingApp2023;

public partial class AutoPage : ContentPage
{
    public FlowDirection Flow = FlowDirection.RightToLeft;
	public string Test = "asdfasdf";

	public AutoPage()
	{
		InitializeComponent();
		BindingContext = MauiProgram.ViewModel;
		NavigatedTo += OnNavigated;
        MauiProgram.ViewModel.AutoStack = stack2;
        MauiProgram.ViewModel.AutoMobility = mobility;
        MauiProgram.ViewModel.AutoDocked = docked;
        MauiProgram.ViewModel.AutoEngaged = engaged;

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