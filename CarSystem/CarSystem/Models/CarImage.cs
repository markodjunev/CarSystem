namespace CarSystem.Models
{
    using CarSystem.Models.Common;

    public class CarImage : BaseDeletableModel<int>
    {
        public int CarId { get; set; }

        public Car Car { get; set; }

        public int ImageId { get; set; }

        public Image Image { get; set; }
    }
}
