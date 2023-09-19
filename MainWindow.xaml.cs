using AutomobileManagement.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace AutomobileManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = App.Current.Services.GetService<MainVM>();
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await ((MainVM)DataContext).Load();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}