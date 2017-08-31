namespace Avatar.Models.Nations
{

    using System.Collections.Generic;
    using Avatar.Models.Benders;
    using Avatar.Models.Monuments;

    public class EarthNation
    {

        private IList<EarthBender> earthBenders;
        private IList<EarthMonument> earthMonuments;

        public EarthNation()
        {
            this.EarthBenders = new List<EarthBender>();
            this.EarthMonuments = new List<EarthMonument>();
        }

        public IList<EarthBender> EarthBenders
        {
            get => this.earthBenders;
            private set => this.earthBenders = value;
        }
        public IList<EarthMonument> EarthMonuments
        {
            get => this.earthMonuments;
            private set => this.earthMonuments = value;
        }
   }
}
