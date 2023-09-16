using AutomobileManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomobileManagement.Repos
{
    public class CarsRepo
    {
        private AppDbContext context;

        public CarsRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Car>> GetCars()
        {
            return await context.Cars.ToListAsync();
        }

        public async Task<Car> GetCar(int id)
        {
            return await context.Cars.FirstAsync(c => c.Id == id);
        }

        public async Task AddCar(Car car)
        {
            context.Cars.Add(car);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCar(Car car)
        {
            context.Cars.Update(car);
            await context.SaveChangesAsync();
        }

        public async Task RemoveCar(Car car)
        {
            context.Cars.Remove(car);
            await context.SaveChangesAsync();
        }
    }
}