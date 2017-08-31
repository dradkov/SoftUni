namespace Avatar.Models.Nations
{

    using System.Collections.Generic;
    using Avatar.Models.Benders;
    using Avatar.Models.Monuments;

    public class FireNation
    {
        private IList<FireBender> fireBenders;
        private IList<FireMonument> fireMonuments;

        public FireNation()
        {
            this.FireBenders = new List<FireBender>();
            this.FireMonuments = new List<FireMonument>();
        }

        public IList<FireBender> FireBenders
        {
            get => this.fireBenders;
            private set => this.fireBenders = value;
        }
        public IList<FireMonument> FireMonuments
        {
            get => this.fireMonuments;
            private set => this.fireMonuments = value;
        }
    }
}
