using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Menus.Services;

namespace Menus.ViewModels;

public partial class HomeViewModel:ViewModelBase
{
    private NavigationService _navigationService;
    
    [ObservableProperty] private bool dialogo;
    
    public HomeViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public HomeViewModel()
    {
        
    }

    [RelayCommand]
    public void aparecer()
    {
        dialogo = !dialogo;
        
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