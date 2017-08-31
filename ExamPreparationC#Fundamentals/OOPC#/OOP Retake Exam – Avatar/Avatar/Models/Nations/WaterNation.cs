namespace Avatar.Models.Nations
{
    using System.Collections.Generic;
    using Avatar.Models.Benders;
    using Avatar.Models.Monuments;

    public class WaterNation
    {
        private IList<WaterBender> waterBenders;
        private IList<WaterMonument> waterMonuments;

        public WaterNation()
        {
            this.WaterBenders = new List<WaterBender>();
            this.WaterMonuments = new List<WaterMonument>();
        }

        public IList<WaterBender> WaterBenders
        {
            get => this.waterBenders;
            private set => this.waterBenders = value;
        }
        public IList<WaterMonument> WaterMonuments
        {
            get => this.waterMonuments;
            private set => this.waterMonuments = value;
        }
    }
}
