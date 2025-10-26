using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Menus.Services;

namespace Menus.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    private NavigationService _navigationService;
    // los observables se declaran en minusculas y se usan en mayusculas
    // Controla el diálogo de "Atención" (Suscripción)
    [ObservableProperty] private bool dialogo;
    
    // Controla el diálogo de "Ayuda" (Flotante)
    [ObservableProperty] private bool dialogoAyuda;


    public HomeViewModel()
    {
    }

    public HomeViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    // Controla el diálogo de "Atención"
    [RelayCommand]
    public void aparecerAtencion()
    {
        Dialogo = !Dialogo;
        
        // Aseguramos que el otro diálogo esté cerrado si este se abre
        if (Dialogo)
        {
            DialogoAyuda = false;
        }
    }
    
    // Controla el diálogo de "Ayuda"
    [RelayCommand]
    public void aparecerAyuda()
    {
        DialogoAyuda = !DialogoAyuda;
        
        // Aseguramos que el otro diálogo esté cerrado si este se abre
        if (DialogoAyuda)
        {
            Dialogo = false;
        }
    }
}