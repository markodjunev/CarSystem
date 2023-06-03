using CarSystem.ViewModels.Images;
using System.Collections.Generic;

namespace CarSystem.ViewModels.Cars
{
    public class CarDetailsViewModel
    {
        public int Id { get; set; }

        public string OwnerName { get; set; }

        public string NumberPlate { get; set; }

        public double EngineCapacity { get; set; }

        public string TypeOfColor { get; set; }

        public int Horsepower { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public List<ImageOriginalPath> ImageUrls { get; set; }
    }
}
