namespace SnakrMauiApp.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class UsersDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	SampleItem item;
}
