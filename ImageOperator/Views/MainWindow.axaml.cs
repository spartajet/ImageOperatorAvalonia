using Avalonia;
using Avalonia.Controls;
using ImageOperator.ViewModels;

namespace ImageOperator.Views;

public partial class MainWindow : Window
{
    private MainWindowViewModel model;

    public MainWindow(MainWindowViewModel model)
    {
        this.InitializeComponent();
        this.model = model;
        this.DataContext = model;
        this.Loaded += (_, _) =>
        {

#if MACOS
        this.WindowState = WindowState.FullScreen;
#endif
        };
    }


}