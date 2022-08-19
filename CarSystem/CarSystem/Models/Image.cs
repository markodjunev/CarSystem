using CarSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.Models
{
    public class Image : BaseDeletableModel<int>
    {
        public Image()
        {
            this.CarImages = new HashSet<CarImage>();
        }

        public string OriginalPath { get; set; }

        public ICollection<CarImage> CarImages { get; set; }
    }
}
