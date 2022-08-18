using CarSystem.Data;
using CarSystem.Models;
using CarSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.Services
{
    public class CarImagesService : ICarImagesService
    {
        private readonly ApplicationDbContext dbContext;

        public CarImagesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(int carId, string imageUrl)
        {
            var carImage = new CarImage
            {
                CarId = carId,
                ImageUrl = imageUrl,
            };

            await this.dbContext.CarImages.AddAsync(carImage);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
