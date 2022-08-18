using CarSystem.Data;
using CarSystem.Models;
using CarSystem.Models.Enums;
using CarSystem.Services.Interfaces;
using CarSystem.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.Services
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext dbContext;

        public CarsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateAsync(string ownerName, string numberPlate, double engineCapacity, 
            TypeOfColor typeOfColor, int horsepower, int makeId, int modelId)
        {
            var car = new Car
            {
                OwnerName = ownerName,
                NumberPlate = numberPlate,
                EngineCapacity = engineCapacity,
                TypeOfColor = typeOfColor,
                Horsepower = horsepower,
                MakeId = makeId,
                ModelId = modelId,
            };

            await this.dbContext.Cars.AddAsync(car);
            await this.dbContext.SaveChangesAsync();

            return car.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var car = this.dbContext.Cars.FirstOrDefault(x => x.Id == id);

            car.IsDeleted = true;
            car.DeletedOn = DateTime.UtcNow;

            this.dbContext.Cars.Update(car);
            await this.dbContext.SaveChangesAsync();
        }

        public bool Exist(int id)
        {
            return this.dbContext.Cars.Any(x => x.Id == id);
        }

        public bool ExistNumberPlate(string numberPlate)
        {
            return this.dbContext.Cars.Any(x => x.NumberPlate == numberPlate);
        }

        public bool ExistNumberPlateInOtherCar(int id, string numberPlate)
        {
            return this.dbContext.Cars.Any(x => x.NumberPlate == numberPlate && x.Id != id);
        }

        public List<CarByMakeViewModel> GetAllByMake(int makeId)
        {
            var cars = this.dbContext.Cars.Where(x => x.MakeId == makeId)
                .Select(x => new CarByMakeViewModel
                {
                    Id = x.Id,
                    OwnerName = x.OwnerName,
                    NumberPlate = x.NumberPlate,
                    EngineCapacity = x.EngineCapacity,
                    Horsepower = x.Horsepower,
                    MakeName = x.Make.Name,
                    ModelName = x.Model.Name,
                    TypeOfColor = x.TypeOfColor.ToString(),
                }).ToList();

            return cars;
        }

        public UpdateCarViewModel GetUpdateModel(int id)
        {
            var car = this.dbContext.Cars.Where(x => x.Id == id).Select(x => new UpdateCarViewModel
            {
                OwnerName = x.OwnerName,
                NumberPlate = x.NumberPlate,
                EngineCapacity = x.EngineCapacity,
                Horsepower = x.Horsepower,
                MakeId = x.MakeId,
                ModelId = x.ModelId,
                TypeOfColor = x.TypeOfColor.ToString(),
            }).FirstOrDefault();

            return car;
        }

        public async Task UpdateAsync(int id, string ownerName, string numberPlate, double engineCapacity, TypeOfColor typeOfColor, int horsepower, int makeId, int modelId)
        {
            var car = this.dbContext.Cars.FirstOrDefault(x => x.Id == id);

            car.OwnerName = ownerName;
            car.NumberPlate = numberPlate;
            car.EngineCapacity = engineCapacity;
            car.TypeOfColor = typeOfColor;
            car.Horsepower = horsepower;
            car.MakeId = makeId;
            car.ModelId = modelId;

            this.dbContext.Cars.Update(car);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
