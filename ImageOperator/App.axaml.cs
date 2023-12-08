using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ImageOperator.Core;
using ImageOperator.ViewModels;
using ImageOperator.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ImageOperator;

public partial class App : Application
{
    private static IHost host => Host.CreateDefaultBuilder().ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(AppContext.BaseDirectory) ?? string.Empty); }).ConfigureServices((context, services) =>
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowViewModel>();
        services.AddPluginFramework<IImageOperator>(@".\Plugins\");
    }).Build();

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        MainWindow? mainWindow = GetService<MainWindow>();
        MainWindowViewModel? mainWindowViewModel = GetService<MainWindowViewModel>();
        if (mainWindow != null && mainWindowViewModel != null)
        {
            mainWindow.DataContext = mainWindowViewModel;
        }

        switch (this.ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                desktop.MainWindow = mainWindow;
                break;
            case ISingleViewApplicationLifetime singleView:
                singleView.MainView = mainWindow;
                break;
        }
#if DEBUG
        this.AttachDevTools();
#endif

        base.OnFrameworkInitializationCompleted();
    }


    public static T? GetService<T>()
    {
        return host.Services.GetService<T>();
    }
    
}