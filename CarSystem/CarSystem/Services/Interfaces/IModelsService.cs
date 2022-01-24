using CarSystem.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.Services.Interfaces
{
    public interface IModelsService
    {
        bool Any();

        Task CreateAsync(string name, int makeId);

        bool Exist(int modelId, int makeId);

        List<ModelViewModel> GetByMakeId(int makeId);
    }
}
