using SnakrMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakrMauiApp.ViewModels
{
    [QueryProperty(nameof(Item), "Item")]
    public partial class MasterUsersDetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        MasterUsersDTO item;
    }
}
