using System.Runtime.InteropServices;
using System.Windows;
using ClassIsland.Core.Abstractions.Services;
using ClassIsland.Shared.Interfaces;
using ClassIsland.Shared.Models.Notification;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Hosting;
using IslandCaller.Controls.NotificationProviders;

namespace IslandCaller.Services.NotificationProviders;

public class IslandCallerNotificationProvider : INotificationProvider, IHostedService
{
    // 定义事件和委托
    public delegate void StudentNameEventHandler(string studentName);
    public static event StudentNameEventHandler? OnStudentNameReceived;

    private INotificationHostService NotificationHostService { get; }
    public IUriNavigationService UriNavigationService { get; }
    public string Name { get; set; } = "IslandCallerServices";
    public string Description { get; set; } = "用于为IslandCaller提供通知接口";
    public Guid ProviderGuid { get; set; } = new Guid("9B570BF1-9A32-40C0-9D5D-4FFA69E03A37");
    public object? SettingsElement { get; set; }
    public object? IconElement { get; set; } =  new PackIcon()
    {
        Kind = PackIconKind.AccountCheck,
        Width = 24,
        Height = 24
    };
    
    /// <summary>
    /// 这个属性用来存储提醒的设置。
    /// </summary>

    public IslandCallerNotificationProvider(INotificationHostService notificationHostService, IUriNavigationService uriNavigationService)
    {
        NotificationHostService = notificationHostService;
        UriNavigationService = uriNavigationService;
        NotificationHostService.RegisterNotificationProvider(this);
        UriNavigationService.HandlePluginsNavigation(
            "IslandCaller/Run",
            args => {
                UriOn(null, EventArgs.Empty);
            }
        );
    }

    [DllImport(".\\Plugins\\Plugin.IslandCaller\\Core.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    public static extern IntPtr GetRandomStudentName();

    private void UriOn(object? sender, EventArgs e)
    {
        int num = 1;
        string filename = @".\Config\Plugins\Plugin.IslandCaller\default.txt";
        IntPtr ptr1 = GetRandomStudentName();
        string output = Marshal.PtrToStringBSTR(ptr1);
        Marshal.FreeBSTR(ptr1); // 释放分配的 BSTR 内存


        // 显示通知
        NotificationHostService.ShowNotification(new NotificationRequest()
        {
            MaskContent = new IslandCallerNotificationControl(output)
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            },
            MaskSpeechContent = output,
            MaskDuration = new TimeSpan(0, 0, 3),
            });
    }


    public async Task StartAsync(CancellationToken cancellationToken)
    {
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
    }
}