using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;
using Menus.Services;
using Menus.Views;

namespace Menus.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    // Lista de Items para le menu
    [ObservableProperty] 
    private NavigationService navigationService = new();
    
    
    // Instanciamos lo que queremos mostrar al iniciar
    public MainViewModel()
    {

    }// final del constructor
    


}// final de la clase