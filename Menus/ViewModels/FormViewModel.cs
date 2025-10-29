using System;
using System.Collections.ObjectModel;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using Menus.Models;
using Menus.Services;

namespace Menus.ViewModels;

public partial class FormViewModel:ViewModelBase
{
    private NavigationService _navigationService;
    
    //Propiedas observables
    
    //Lista de lenguajesSelected
    [ObservableProperty] private ObservableCollection<LanguageModel> laguageSelected = new();
    
    //Lista de entornosSelected
    [ObservableProperty] private ObservableCollection<LanguageModel> entornoSelected = new();
    
    
    public FormViewModel()
    {
        
    }
    
    
    public FormViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
        LoadLanguageSelectedList();
        LoadEntornoSelectedList();
    }
    
    private void LoadLanguageSelectedList(){
        
        string[] nombresLenguageSelected = new string[]
        {
            
        };

        foreach (var name in nombresLenguageSelected)
        {
            string nombreArchivo = $"{name}.png"; 
            
            var uri = new Uri($"avares://Menus/Assets/Languages/{nombreArchivo}");
            
            LaguageSelected.Add(new LanguageModel() { ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = name });
        }

    }
    
    private void LoadEntornoSelectedList(){
        
        string[] nombresEntornoSelected = new string[]
        {
            
        };

        foreach (var name in nombresEntornoSelected)
        {
            string nombreArchivo = $"{name}.png"; 
            
            var uri = new Uri($"avares://Menus/Assets/Entornos/{nombreArchivo}");
            
            EntornoSelected.Add(new LanguageModel() { ImagePath = new Bitmap(AssetLoader.Open(uri)), Name = name });
        }

    }
    
    
    
}