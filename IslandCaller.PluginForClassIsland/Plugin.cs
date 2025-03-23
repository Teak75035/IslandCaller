using ClassIsland.Core;
using ClassIsland.Core.Abstractions;
using ClassIsland.Core.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IslandCaller.Services.NotificationProviders;
using ClassIsland.Core.Extensions.Registry;
using IslandCaller.Views.SettingsPages;
using IslandCaller.Views.Windows;
using System.IO;
using IslandCaller.Models;
using ClassIsland.Shared.Helpers;

namespace IslandCaller;

[PluginEntrance]
public class Plugin : PluginBase
{
    public Settings Settings { get; set; } = new();
    public override void Initialize(HostBuilderContext context, IServiceCollection services)
    {
        services.AddHostedService<IslandCallerNotificationProvider>();
        services.AddSettingsPage<IslandCallerSettingsPage>();
        Settings = ConfigureFileHelper.LoadConfig<Settings>(Path.Combine(PluginConfigFolder, "Settings.json"));
        Settings.PropertyChanged += (sender, args) =>
        {
            ConfigureFileHelper.SaveConfig<Settings>(Path.Combine(PluginConfigFolder, "Settings.json"), Settings);
        };

        AppBase.Current.AppStarted += (_, _) =>
        {
            if (Settings.IsHoverShow)
            {
                Hover.Instance ??= new Hover(this);
                Hover.Instance.Show();
            }
        };
    }
}
