namespace SnakrMauiApp.Views;

public partial class MasterUsersPage : ContentPage
{
	MasterUsersViewModel ViewModel;

	public MasterUsersPage(MasterUsersViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = ViewModel = viewModel;
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		await ViewModel.LoadDataAsync();
	}
}
