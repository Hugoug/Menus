using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Menus.Services;

namespace Menus.ViewModels;

public partial class ShopViewModel:ViewModelBase
{
    private NavigationService _navigationService;
    
    [ObservableProperty] private int pageIndex = 0;
    [ObservableProperty] private bool isReverse = false;

    public ShopViewModel()
    {
        
    }
    public ShopViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void irAInicio()
    {
        PageIndex = 0;
    }
    
    [RelayCommand]
    public void irAUsuarios()
    {
        PageIndex = 1;
    }
    
    [RelayCommand]
    public void irAConfig()
    {
        PageIndex = 2;
    }

    [RelayCommand]
    public void NavigateInicio()
    {
        _navigationService.NavigateTo("inicio");
    }
    
    [RelayCommand]
    public void NavigateCarrito()
    {
        _navigationService.NavigateTo("carrito");
    }
}