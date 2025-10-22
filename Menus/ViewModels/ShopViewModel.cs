using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Menus.Models;
using Menus.Services;

namespace Menus.ViewModels;

public partial class ShopViewModel:ViewModelBase
{
    private NavigationService _navigationService;
    
    [ObservableProperty] private int pageIndex = 0;
    [ObservableProperty] private bool isReverse = false;
    
    //Lista de lenguajes
    [ObservableProperty] private ObservableCollection<LanguageModel> languageList = new();
    
    
    public ShopViewModel()
    {
        
    }
    public ShopViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
        LoadLanguageList();
    }

    [RelayCommand]
    public void irAtras()
    {
        if (PageIndex == 0)
        {
            PageIndex = 2;
        }
        
        if (PageIndex == 1)
        {
            PageIndex = 0;
        }
        
        if (PageIndex == 2)
        {
            PageIndex = 1;
        }
        
    }
    
    [RelayCommand]
    public void irAdelante()
    {
        if (PageIndex == 0)
        {
            PageIndex = 1;
        }
        
        if (PageIndex == 1)
        {
            PageIndex = 2;
        }
        
        if (PageIndex == 2)
        {
            PageIndex = 0;
        }
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

    private void LoadLanguageList(){
        
        var uri = new Uri("avares://Menus/Assets/Languages/Python.png");
        LanguageList.Add(new LanguageModel() { ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "Python" });

        uri = new Uri("avares://Menus/Assets/Languages/Java.png");
        LanguageList.Add(new LanguageModel() { ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "Java" });
        
        uri = new Uri("avares://Menus/Assets/Languages/JavaScript.png");
        LanguageList.Add(new LanguageModel() { ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "JavaScript" });
        
        uri = new Uri("avares://Menus/Assets/Languages/SQL.png");
        LanguageList.Add(new LanguageModel() { ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "SQL" });
        
        uri = new Uri("avares://Menus/Assets/Languages/C.png");
        LanguageList.Add(new LanguageModel() { ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "C" });
        
        uri = new Uri("avares://Menus/Assets/Languages/C++.png");
        LanguageList.Add(new LanguageModel() { ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "C++" });
        
        uri = new Uri("avares://Menus/Assets/Languages/C#.png");
        LanguageList.Add(new LanguageModel() { ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "C#" });
        
        uri = new Uri("avares://Menus/Assets/Languages/Cobol.png");
        LanguageList.Add(new LanguageModel() { ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "Cobol" });
        
        uri = new Uri("avares://Menus/Assets/Languages/Kotlin.png");
        LanguageList.Add(new LanguageModel() { ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "Kotlin" });
    }
}