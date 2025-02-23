using ClassIsland.Core.Abstractions;
using ClassIsland.Core.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IslandCaller.Services.NotificationProviders;
using ClassIsland.Core.Extensions.Registry;
using IslandCaller.Views.SettingsPages;
namespace IslandCaller;

[PluginEntrance]
public class Plugin : PluginBase
{
    public override void Initialize(HostBuilderContext context, IServiceCollection services)
    {
        services.AddHostedService<IslandCallerNotificationProvider>();
        services.AddSettingsPage<IslandCallerSettingsPage>();
    }
}