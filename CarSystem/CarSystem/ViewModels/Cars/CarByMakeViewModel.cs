using CarSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.ViewModels.Cars
{
    public class CarByMakeViewModel
    {
        public int Id { get; set; }

        public string OwnerName { get; set; }

        public string NumberPlate { get; set; }

        public double EngineCapacity { get; set; }

        public TypeOfColor TypeOfColor { get; set; }

        public int Horsepower { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }
    }
}
