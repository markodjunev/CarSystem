using CarSystem.Data;
using CarSystem.Models;
using CarSystem.Services.Interfaces;
using CarSystem.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.Services
{
    public class ModelsService : IModelsService
    {
        private readonly ApplicationDbContext dbContext;

        public ModelsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Any()
        {
            return this.dbContext.Models.Any();
        }

        public async Task CreateAsync(string name, int makeId)
        {
            var model = new Model
            {
                Name = name,
                MakeId = makeId,
            };

            await this.dbContext.Models.AddAsync(model);
            await this.dbContext.SaveChangesAsync();
        }

        public bool Exist(int modelId, int makeId)
        {
            return this.dbContext.Models.Any(x => x.Id == modelId && x.MakeId == makeId);
        }

        public List<ModelViewModel> GetByMakeId(int makeId)
        {
            var models = this.dbContext.Models.Where(x => x.MakeId == makeId)
                .Select(x => new ModelViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();

            return models;
        }
    }
}
