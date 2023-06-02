namespace SnakrMauiApp.ViewModels;

public partial class MasterUsersViewModel : BaseViewModel
{
    readonly SnakrDataService dataService;

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    ObservableCollection<MasterUsersDTO> items;

    public MasterUsersViewModel(SnakrDataService service)
    {
        dataService = service;
    }

    [RelayCommand]
    private async void OnRefreshing()
    {
        IsRefreshing = true;

        try
        {
            await LoadDataAsync();
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    public async Task LoadMore()
    {
        var items = await dataService.GetMasterUsersAsync();

        foreach (var item in items)
        {
            Items.Add(item);
        }
    }

    public async Task LoadDataAsync()
    {
        Items = new ObservableCollection<MasterUsersDTO>(await dataService.GetMasterUsersAsync());
    }

    //[RelayCommand]
    //private async void GoToDetails(MasterUsersDTO item)
    //{
    //    await Shell.Current.GoToAsync(nameof(UsersDetailPage), true, new Dictionary<string, object>
    //    {
    //        { "Item", item }
    //    });
    //}
}
