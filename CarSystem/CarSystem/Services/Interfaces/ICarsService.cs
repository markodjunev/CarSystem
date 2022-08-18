using CarSystem.Models.Enums;
using CarSystem.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.Services.Interfaces
{
    public interface ICarsService
    {
        Task<int> CreateAsync(string ownerName, string numberPlate, double engineCapacity, TypeOfColor typeOfColor,
            int horsepower, int makeId, int modelId);

        bool ExistNumberPlate(string numberPlate);

        Task UpdateAsync(int id, string ownerName, string numberPlate, double engineCapacity, TypeOfColor typeOfColor,
            int horsepower, int makeId, int modelId);

        bool Exist(int id);

        bool ExistNumberPlateInOtherCar(int id, string numberPlate);

        UpdateCarViewModel GetUpdateModel(int id);

        List<CarByMakeViewModel> GetAllByMake(int makeId);

        Task DeleteAsync(int id);
    }
}
