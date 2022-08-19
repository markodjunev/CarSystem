using CarSystem.Models.Enums;
using CarSystem.Services.Interfaces;
using CarSystem.ViewModels.Cars;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.Controllers
{
    public class CarsController : ApiController
    {
        private readonly ICarsService carsService;
        private readonly IMakesService makesService;
        private readonly IModelsService modelsService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly ICarImagesService carImagesService;
        private readonly IImagesService imagesService;

        public CarsController(ICarsService carsService, IMakesService makesService, IModelsService modelsService, ICloudinaryService cloudinaryService,
            ICarImagesService carImagesService, IImagesService imagesService)
        {
            this.carsService = carsService;
            this.makesService = makesService;
            this.modelsService = modelsService;
            this.cloudinaryService = cloudinaryService;
            this.carImagesService = carImagesService;
            this.imagesService = imagesService;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create([FromForm]CreateCarInputModel input)
        {
            var existNumberPlate = this.carsService.ExistNumberPlate(input.NumberPlate);

            if (existNumberPlate)
            {
                return BadRequest("Please enter a unique number plate. The inserted on already exists.");
            }

            var makeExist = this.makesService.Exist(input.MakeId);

            if (!makeExist)
            {
                return BadRequest("Please insert a valid make!");
            }

            var modelExist = this.modelsService.Exist(input.ModelId, input.MakeId);

            if (!modelExist)
            {
                return BadRequest("Please insert a valid model!");
            }

            TypeOfColor typeOfColor = (TypeOfColor)Enum.Parse(typeof(TypeOfColor), input.TypeOfColor);

            var carId = await this.carsService.CreateAsync(input.OwnerName, input.NumberPlate, input.EngineCapacity,
                typeOfColor, input.Horsepower, input.MakeId, input.ModelId);

            foreach (var image in input.Images)
            {
                string originalPathImageUrl = await this.cloudinaryService.UploadPictureAsync(
                image,
                input.OwnerName);

                var imageId = await this.imagesService.CreateAsync(originalPathImageUrl);

                await this.carImagesService.CreateAsync(carId, imageId);
            }

            return Ok();
        }

        [HttpPut]
        [Route(nameof(Edit) + "/{id}")]
        public async Task<IActionResult> Edit(int id, EditCarInputModel input)
        {
            var existCar = this.carsService.Exist(id);

            if (!existCar)
            {
                return NotFound();
            }

            var existNumberPlateInOtherCar = this.carsService.ExistNumberPlateInOtherCar(id, input.NumberPlate);

            if (existNumberPlateInOtherCar)
            {
                return BadRequest("Please enter a unique number plate. The inserted on already exists.");
            }

            var makeExist = this.makesService.Exist(input.MakeId);

            if (!makeExist)
            {
                return BadRequest("Please insert a valid make!");
            }

            var modelExist = this.modelsService.Exist(input.ModelId, input.MakeId);

            if (!modelExist)
            {
                return BadRequest("Please insert a valid model!");
            }


            try
            {
                TypeOfColor typeOfColor = (TypeOfColor)Enum.Parse(typeof(TypeOfColor), input.TypeOfColor);
                await this.carsService.UpdateAsync(id, input.OwnerName, input.NumberPlate, input.EngineCapacity,
                typeOfColor, input.Horsepower, input.MakeId, input.ModelId);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("The color doesn't exist!");
            }
        }

        [HttpGet]
        [Route(nameof(UpdateModel) + "/{id}")]
        public ActionResult<UpdateCarViewModel> UpdateModel(int id)
        {
            var existCar = this.carsService.Exist(id);

            if (!existCar)
            {
                return NotFound();
            }

            var car = this.carsService.GetUpdateModel(id);

            return Ok(car);
        }

        [HttpGet]
        [Route(nameof(CarsByMake) + "/{id}")]
        public ActionResult<CarByMakeViewModel> CarsByMake(int id)
        {
            var existMake = this.makesService.Exist(id);

            if (!existMake)
            {
                return NotFound("Make doesn't exist!");
            }

            var cars = this.carsService.GetAllByMake(id);

            return Ok(cars);
        }

        [HttpDelete]
        [Route(nameof(Delete) + "/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var carExist = this.carsService.Exist(id);

            if (!carExist)
            {
                return NotFound("Car doesn't exist!");
            }

            await this.carsService.DeleteAsync(id);

            return Ok();
        }
    }
}
