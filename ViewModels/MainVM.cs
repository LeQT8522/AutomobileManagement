using AutomobileManagement.Models;
using AutomobileManagement.Repos;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomobileManagement.ViewModels
{
    public class MainVM : ObservableObject
    {
        private CarsRepo carsRepo;

        public ObservableCollection<Car> Cars { get; } = new();

        private Car selectedCar = new Car();

        public Car SelectedCar
        {
            get => selectedCar;
            set
            {
                SetProperty(ref selectedCar, value);
                Id = value?.Id ?? 0;
                Name = value?.Name ?? string.Empty;
                Manufacturer = value?.Manufacturer ?? string.Empty;
                Price = value?.Price ?? 0;
                ReleaseYear = value?.ReleaseYear ?? 0;
            }
        }

        private int id;

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        private string name = string.Empty;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string manufacturer = string.Empty;

        public string Manufacturer
        {
            get => manufacturer;
            set => SetProperty(ref manufacturer, value);
        }

        private decimal price;

        public decimal Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        private int releaseYear;

        public int ReleaseYear
        {
            get => releaseYear;
            set => SetProperty(ref releaseYear, value);
        }

        public ICommand LoadCmd { get; }
        public ICommand AddCarCmd { get; }
        public ICommand UpdateCarCmd { get; }
        public ICommand RemoveCarCmd { get; }

        public MainVM(CarsRepo carsRepo)
        {
            this.carsRepo = carsRepo;

            LoadCmd = new AsyncRelayCommand(Load);
            AddCarCmd = new AsyncRelayCommand(AddCar);
            UpdateCarCmd = new AsyncRelayCommand(UpdateCar);
            RemoveCarCmd = new AsyncRelayCommand(RemoveCar);
        }

        public async Task Load()
        {
            Cars.Clear();
            var cars = await carsRepo.GetCars();
            cars.ForEach(car => Cars.Add(car));
        }

        private async Task AddCar()
        {
            var newCar = new Car()
            {
                Name = Name,
                Manufacturer = Manufacturer,
                Price = Price,
                ReleaseYear = ReleaseYear
            };
            await carsRepo.AddCar(newCar);
            await Load();
        }

        private async Task UpdateCar()
        {
            selectedCar.Name = Name;
            selectedCar.Manufacturer = Manufacturer;
            selectedCar.Price = Price;
            selectedCar.ReleaseYear = ReleaseYear;
            await carsRepo.UpdateCar(selectedCar);
            await Load();
        }

        private async Task RemoveCar()
        {
            await carsRepo.RemoveCar(SelectedCar);
            await Load();
            SelectedCar = new Car();
        }
    }
}