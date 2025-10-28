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

public partial class ShopViewModel:ViewModelBase
{
    private NavigationService _navigationService;
    
    //Propiedas observables
    [ObservableProperty] private int pageIndex = 0;
    [ObservableProperty] private bool isReverse = false;
    [ObservableProperty] private bool isLanguageSelected;
    
    //Mensaje informativo para la seleccion de lenguajes y entornos
    [ObservableProperty] private string info  = string.Empty;
    
    //Lista de lenguajes
    [ObservableProperty] private ObservableCollection<LanguageModel> languageList = new();
    [ObservableProperty] private ObservableCollection<LanguageModel> selectedLanguages = new();
    //Lista de entornos
    [ObservableProperty] private ObservableCollection<LanguageModel> entornosList = new();
    [ObservableProperty] private ObservableCollection<LanguageModel> selectedEntornos = new();
    
    
    public ShopViewModel()
    {
        
    }

    partial void OnSelectedLanguagesChanged(ObservableCollection<LanguageModel> value)
    {
        Console.WriteLine("");
    }
    
    public ShopViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
        LoadLanguageList();
        LoadEntornoList();
    }
    
    [RelayCommand]
    public void SelectedLanguagesChanged()
    {
        if (SelectedLanguages.Count == 0)
        {
            IsLanguageSelected = false;
        }
        else
        {
            IsLanguageSelected = true;
        }
        if (SelectedLanguages.Count == 5)
        {
            SelectedLanguages.Remove(SelectedLanguages.Last());
            return;
        }
        
        Info = "HAS SELECCIONADO: " +SelectedLanguages.Count+ "/4";
    }
    
    [RelayCommand]
    public void SelectedEntornosChanged()
    {
        if (SelectedEntornos.Count == 5)
        {
            SelectedEntornos.Remove(SelectedEntornos.Last());
            return;
        }
        
        Info = "HAS SELECCIONADO: " +SelectedEntornos.Count+ "/4";
    }
    
    // [RelayCommand]
    // public void Seleccion(object parameter)
    // {
    //     Boolean tarjeta = (Boolean)parameter;
    //     if (!tarjeta)
    //     {
    //         Info = "Debes seleccionar mínimo 1 y máximo 3";
    //         Console.WriteLine("Debes seleccionar mínimo 1 y máximo 3");
    //         return;
    //     }
    //     else
    //     {
    //         irAdelante();
    //     }
    //     
    //
    // }
    
    

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
            
            LanguageList.Add(new LanguageModel() { ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = name });
        }

    }
    
    private void LoadEntornoList(){
        
        string[] nombresEntorno = new string[]
        {
            "Android", "Eclipse", "VisualStudio", "IntelliJ", "PyCharm", "Rider", "NetBeans", "Vim", "Xcode"
        };

        foreach (var name in nombresEntorno)
        {
            string nombreArchivo = $"{name}.png"; 
            
            var uri = new Uri($"avares://Menus/Assets/Entornos/{nombreArchivo}");
            
            EntornosList.Add(new LanguageModel() { ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = name });
        }

    }

}