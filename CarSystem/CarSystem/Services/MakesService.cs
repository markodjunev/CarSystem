using CarSystem.Data;
using CarSystem.Models;
using CarSystem.Services.Interfaces;
using CarSystem.ViewModels.Makes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.Services
{
    public class MakesService : IMakesService
    {
        private readonly ApplicationDbContext dbContext;

        public MakesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Any()
        {
            return this.dbContext.Makes.Any();
        }

        public async Task CreateAsync(string name)
        {
            var make = new Make
            {
                Name = name
            };

            await this.dbContext.Makes.AddAsync(make);
            await this.dbContext.SaveChangesAsync();
        }

        public bool Exist(int id)
        {
            return this.dbContext.Makes.Any(x => x.Id == id);
        }

        public List<MakeViewModel> Get()
        {
            var makes = this.dbContext.Makes.Select(x => new MakeViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return makes;
        }
    }
}
