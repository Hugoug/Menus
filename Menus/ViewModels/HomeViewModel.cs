using CommunityToolkit.Mvvm.Input;
using Menus.Services;

namespace Menus.ViewModels;

public partial class HomeViewModel:ViewModelBase
{
    private NavigationService _navigationService;
    
    public HomeViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public HomeViewModel()
    {
        
    }

    [RelayCommand]
    public void NavigateTienda()
    {
        _navigationService.NavigateTo("tienda");
    }
    
    [RelayCommand]
    public void NavigateCarrito()
    {
        _navigationService.NavigateTo("carrito");
    }
}