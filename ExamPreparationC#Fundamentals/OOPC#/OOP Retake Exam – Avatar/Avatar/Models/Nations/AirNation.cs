namespace Avatar.Models.Nations
{

    using System.Collections;
    using System.Collections.Generic;
    using Avatar.Models.Benders;
    using Avatar.Models.Monuments;

    public class AirNation
    {

        private IList<AirBender> airBenders;
        private IList<AirMonument> airMonuments;

        public AirNation()
        {
            this.AirBenders = new List<AirBender>();
            this.AirMonuments = new List<AirMonument>();
        }

        public IList<AirBender> AirBenders
        {
            get => this.airBenders;
            private set => this.airBenders = value;
        }

        public IList<AirMonument> AirMonuments
        {
            get => this.airMonuments;
            private set => this.airMonuments = value;
        }
    }
}
