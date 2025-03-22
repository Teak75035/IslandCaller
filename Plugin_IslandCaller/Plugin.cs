using ClassIsland.Core;
using ClassIsland.Core.Abstractions;
using ClassIsland.Core.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IslandCaller.Services.NotificationProviders;
using ClassIsland.Core.Extensions.Registry;
using IslandCaller.Views.SettingsPages;
using Plugin_IslandCaller.Views.Windows;
using System.IO;

namespace IslandCaller;

[PluginEntrance]
public class Plugin : PluginBase
{
    public override void Initialize(HostBuilderContext context, IServiceCollection services)
    {
        services.AddHostedService<IslandCallerNotificationProvider>();
        services.AddSettingsPage<IslandCallerSettingsPage>();
        Hover.ConfigFolder = PluginConfigFolder;
        AppBase.Current.AppStarted += (_,_) => {
            if (File.Exists(Path.Combine(PluginConfigFolder,"enableHover.flag")))
            {
                Hover.Instance ??= new Hover();
                Hover.Instance.Show();
            }
        };
    }
}