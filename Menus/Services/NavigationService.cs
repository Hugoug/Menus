using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;
using Menus.ViewModels;
using Menus.Views;

namespace Menus.Services;

public partial class NavigationService : ObservableObject
{
    [ObservableProperty] private ContentControl currentView;

    [ObservableProperty] private NavigationViewItem selectedMenuItem;

    //si es observable al usarlo, en mayuscula
    [ObservableProperty] private ObservableCollection<NavigationViewItem> menuItems = new();

    private NavigationViewItem item1;
    private NavigationViewItem item2;
    private NavigationViewItem item3;

    public NavigationService()
    {
        item1 = new NavigationViewItem()
        {
            Content = "Inicio",
            Tag = "inicio",
            IconSource = new SymbolIconSource { Symbol = Symbol.Home }
        };

        item2 = new NavigationViewItem()
        {
            Content = "Tienda",
            Tag = "tienda",
            IconSource = new SymbolIconSource { Symbol = Symbol.Shop }
        };

        item3 = new NavigationViewItem()
        {
            Content = "Listas",
            Tag = "listas",
            IconSource = new SymbolIconSource { Symbol = Symbol.Library }
        };

        // Añadimos los items a la lista
        MenuItems.Add(item1);
        MenuItems.Add(item2);
        MenuItems.Add(item3);

        SelectedMenuItem = item1;
    }

    partial void OnSelectedMenuItemChanged(NavigationViewItem item)
    {
        NavigateTo(item.Tag.ToString());
    }

    // recibe el tag y cambiad de pagina
    public void NavigateTo(string tag)
    {
        if (tag.Equals("inicio"))
        {
            HomeView homeView = new HomeView();
            homeView.DataContext = new HomeViewModel(this);
            CurrentView = homeView;
            SelectedMenuItem = MenuItems[0];
        }
        else if (tag.Equals("tienda"))
        {
            ShopView shopView = new ShopView();
            shopView.DataContext = new ShopViewModel(this);
            CurrentView = shopView;
            SelectedMenuItem = MenuItems[1];
        }
        else if (tag.Equals("listas"))
        {
            ListasView listasView = new ListasView();
            listasView.DataContext = new ListasViewModel(this);
            CurrentView = listasView;
            SelectedMenuItem = MenuItems[2];
        }
    }
}