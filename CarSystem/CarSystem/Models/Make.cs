namespace CarSystem.Models
{
    using CarSystem.Models.Common;
    using System.Collections.Generic;

    public class Make : BaseDeletableModel<int>
    {
        public Make()
        {
            this.Cars = new HashSet<Car>();
            this.Models = new HashSet<Model>();
        }

        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
