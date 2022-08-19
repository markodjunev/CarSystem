using CarSystem.Data;
using CarSystem.Models;
using CarSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.Services
{
    public class ImagesService : IImagesService
    {
        private readonly ApplicationDbContext dbContext;

        public ImagesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateAsync(string originalPath)
        {
            var image = new Image
            {
                OriginalPath = originalPath,
            };

            await this.dbContext.AddAsync(image);
            await this.dbContext.SaveChangesAsync();

            return image.Id;
        }
    }
}
