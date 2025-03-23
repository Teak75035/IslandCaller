using ClassIsland.Core;
using ClassIsland.Core.Commands;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using IslandCaller.Services.NotificationProviders;
using IslandCaller.Views.SettingsPages;
using IslandCaller.Models;

namespace IslandCaller.Views.Windows;

public partial class Hover : Window
{
    public static Hover? Instance;

    public Plugin Plugin { get; }
    public Hover(Plugin plugin)
    {
        Plugin = plugin;
        InitializeComponent();
        DataContext = this;

        // 根据设置控制窗口的显示
        if (!Plugin.Settings.IsHoverShow)
        {
            this.Hide();
        }
        else
        {
            this.Show();
        }

        // 监听设置变化
        Plugin.Settings.PropertyChanged += Settings_PropertyChanged;
    }

    private void Settings_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Settings.IsHoverShow))
        {
            if (Plugin.Settings.IsHoverShow)
            {
                this.Show();
            }
            else
            {
                this.Hide();
            }
        }
    }

    void Hover_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        RandomCall(null, EventArgs.Empty);
    }

    private void RandomCall(object? sender, EventArgs e)
    {
        UriNavigationCommands.UriNavigationCommand.Execute("classisland://plugins/IslandCaller/Run");
    }
}
