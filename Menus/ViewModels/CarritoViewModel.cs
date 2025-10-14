using CommunityToolkit.Mvvm.Input;
using Menus.Services;

namespace Menus.ViewModels;

public partial class CarritoViewModel:ViewModelBase
{
    private NavigationService _navigationService;
    
    public CarritoViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void NavigateInicio()
    {
        _navigationService.NavigateTo("inicio");
    }
    
    [RelayCommand]
    public void NavigateTienda()
    {
        _navigationService.NavigateTo("tienda");
    }
}