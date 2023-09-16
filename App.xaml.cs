using AutomobileManagement.Models;
using AutomobileManagement.Repos;
using AutomobileManagement.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace AutomobileManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
            InitializeComponent();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<AppDbContext>();
            services.AddTransient<CarsRepo>();
            services.AddTransient<MainVM>();

            return services.BuildServiceProvider();
        }
    }
}