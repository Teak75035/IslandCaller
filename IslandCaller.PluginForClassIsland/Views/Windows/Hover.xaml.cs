using ClassIsland.Core;
using ClassIsland.Core.Commands;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace IslandCaller.Views.Windows;

public partial class Hover : Window
{
    public static Hover? Instance;
    public static string? ConfigFolder;

    public Hover()
    {
        InitializeComponent();
    }

    void Hover_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        UriNavigationCommands.UriNavigationCommand.Execute("classisland://plugins/IslandCaller/Run");
    }
}