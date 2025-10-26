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
        // Si estamos en 0, vamos al final (2).
        if (PageIndex == 0)
        {
            PageIndex = 2;
        } 
        // Si estamos en 2, vamos a 1.
        else if (PageIndex == 2)
        {
            PageIndex = 1;
        }
        // Si estamos en 1, vamos a 0.
        else if (PageIndex == 1) 
        {
            PageIndex = 0;
        }
    }

    [RelayCommand]
    public void irAdelante()
    {
        // Si estamos en 2, vamos al inicio (0).
        if (PageIndex == 2)
        {
            PageIndex = 0;
        }
        // Si estamos en 1, vamos a 2.
        else if (PageIndex == 1)
        {
            PageIndex = 2;
        }
        // Si estamos en 0, vamos a 1.
        else if (PageIndex == 0) 
        {
            PageIndex = 1;
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
        
        // var uri = new Uri("avares://Menus/Assets/Languages/Python.png");
        // LanguageList.Add(new LanguageModel() { ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "Python" });

        // uri = new Uri("avares://Menus/Assets/Languages/Java.png");
        // LanguageList.Add(new LanguageModel() { ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = "Java" });
        
        string[] nombresLenguage = new string[]
        {
            "Python", "Java", "JavaScript", "SQL", "C", "C++", "C#", "Cobol", "Kotlin"
        };

        foreach (var name in nombresLenguage)
        {
            string nombreArchivo = $"{name}.png"; 
            
            var uri = new Uri($"avares://Menus/Assets/Languages/{nombreArchivo}");
            
            LanguageList.Add(new LanguageModel() {
                // Usamos el AssetLoader para abrir y crear el Bitmap
                ImagePath = new Bitmap(AssetLoader.Open(uri)),
                Name = name 
            });
        }

    }
    
    private void LoadEntornoList(){
        
        string[] nombresEntorno = new string[]
        {
            "Python", "Java", "JavaScript", "SQL", "C", "C++", "C#", "Cobol", "Kotlin"
        };

        foreach (var name in nombresEntorno)
        {
            string nombreArchivo = $"{name}.png"; 
            
            var uri = new Uri($"avares://Menus/Assets/Languages/{nombreArchivo}");
            
            LanguageList.Add(new LanguageModel() {
                // Usamos el AssetLoader para abrir y crear el Bitmap
                ImagePath = new Bitmap(AssetLoader.Open(uri)),
                Name = name 
            });
        }

    }

}