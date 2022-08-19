namespace CarSystem.Models
{
    using CarSystem.Models.Common;
    using CarSystem.Models.Enums;
    using System.Collections.Generic;

    public class Car : BaseDeletableModel<int>
    {
        public Car()
        {
            this.CarImages = new HashSet<CarImage>();
        }

        public string OwnerName { get; set; }

        public string NumberPlate { get; set; }

        public double EngineCapacity { get; set; }

        public TypeOfColor TypeOfColor { get; set; }

        public int Horsepower { get; set; }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

        public int ModelId { get; set; }

        public virtual Model Model { get; set; }

        public ICollection<CarImage> CarImages { get; set; }
    }
}
