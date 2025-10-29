using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Menus.Models;
using Menus.Services;

namespace Menus.ViewModels;

public partial class ShopViewModel : ViewModelBase
{
    private NavigationService _navigationService;

    public ShopViewModel()
    {
    }

    public ShopViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
    }
}