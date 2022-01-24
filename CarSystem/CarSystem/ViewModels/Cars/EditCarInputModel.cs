using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;

    public class EditCarInputModel
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
        public int MakeId { get; set; }

        [Required]
        public int ModelId { get; set; }
    }
}
