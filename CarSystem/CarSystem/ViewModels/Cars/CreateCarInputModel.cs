﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarSystem.ViewModels.Cars
{
    public class CreateCarInputModel
    {
        [Required]
        public string OwnerName { get; set; }

        [Required]
        public string NumberPlate { get; set; }

        [Required]
        public double EngineCapacity { get; set; }

        [Required]
        public string TypeOfColor { get; set; }

        [Required]
        public int Horsepower { get; set; }

        [Required]
        public List<IFormFile> Images { get; set; }

        [Required]
        public int MakeId { get; set; }

        [Required]
        public int ModelId { get; set; }
    }
}
