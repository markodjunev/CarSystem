using CarSystem.ViewModels.Makes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.Services.Interfaces
{
    public interface IMakesService
    {
        bool Any();

        Task CreateAsync(string name);

        bool Exist(int id);

        List<MakeViewModel> Get(); 
    }
}
