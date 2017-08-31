namespace Avatar.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Avatar.Interfaces;
    using Avatar.Models.Benders;
    using Avatar.Models.Monuments;
    using Avatar.Models.Nations;

    public class NationsBuilder : INationsBuilder
    {

        private AirNation airNation;
        private EarthNation earthNation;
        private FireNation fireNation;
        private WaterNation waterNation;

        private IList<string> issuedWarNation;

        public NationsBuilder()
        {
            this.airNation = new AirNation();
            this.earthNation = new EarthNation();
            this.fireNation = new FireNation();
            this.waterNation = new WaterNation();

            this.issuedWarNation = new List<string>();
        }


        public void AssignBender(List<string> benderArgs)
        {
            string type = benderArgs[0];
            string name = benderArgs[1];
            int power = int.Parse(benderArgs[2]);
            double secondaryParameter = double.Parse(benderArgs[3]);

            switch (type)
            {
                case "Air":
                    airNation.AirBenders.Add(new AirBender(name, power, secondaryParameter));
                    break;
                case "Earth":
                    earthNation.EarthBenders.Add(new EarthBender(name, power, secondaryParameter));
                    break;
                case "Fire":
                    fireNation.FireBenders.Add(new FireBender(name, power, secondaryParameter));
                    break;
                case "Water":
                    waterNation.WaterBenders.Add(new WaterBender(name, power, secondaryParameter));
                    break;

                default:
                    throw new ArgumentException("Bender creation error.");
            }

        }

        public void AssignMonument(List<string> monumentArgs)
        {
            string type = monumentArgs[0];
            string name = monumentArgs[1];
            int affinity = int.Parse(monumentArgs[2]);

            switch (type)
            {
                case "Air":
                    airNation.AirMonuments.Add(new AirMonument(name, affinity));
                    break;
                case "Earth":
                    earthNation.EarthMonuments.Add(new EarthMonument(name, affinity));
                    break;
                case "Fire":
                    fireNation.FireMonuments.Add(new FireMonument(name, affinity));
                    break;
                case "Water":
                    waterNation.WaterMonuments.Add(new WaterMonument(name, affinity));
                    break;

                default:
                    throw new ArgumentException("Monument creation error.");
            }

        }

        public string GetStatus(string nationsType)
        {

            StringBuilder sb = new StringBuilder();
            switch (nationsType)
            {
                case "Air":
                    {
                        sb.AppendLine("Air Nation");

                        if (airNation.AirBenders.Count != 0)
                        {
                            sb.AppendLine("Benders:");
                            foreach (var bender in airNation.AirBenders)
                            {
                                sb.AppendLine(bender.ToString());
                            }
                        }
                        else
                        {
                            sb.AppendLine("Benders: None");
                        }
                        if (airNation.AirMonuments.Count != 0)
                        {
                            sb.AppendLine("Monuments:");
                            foreach (var monument in airNation.AirMonuments)
                            {
                                sb.AppendLine(monument.ToString());
                            }
                        }
                        else
                        {
                            sb.AppendLine("Monuments: None");
                        }

                    }

                    break;

                case "Fire":
                    {
                        sb.AppendLine("Fire Nation");

                        if (fireNation.FireBenders.Count != 0)
                        {
                            sb.AppendLine("Benders:");
                            foreach (var bender in fireNation.FireBenders)
                            {
                                sb.AppendLine(bender.ToString());
                            }
                        }
                        else
                        {
                            sb.AppendLine("Benders: None");
                        }
                        if (fireNation.FireMonuments.Count != 0)
                        {
                            sb.AppendLine("Monuments:");
                            foreach (var monument in fireNation.FireMonuments)
                            {
                                sb.AppendLine(monument.ToString());
                            }
                        }
                        else
                        {
                            sb.AppendLine("Monuments: None");
                        }

                    }
                    break;
                case "Earth":
                    {
                        sb.AppendLine("Earth Nation");

                        if (earthNation.EarthBenders.Count != 0)
                        {
                            sb.AppendLine("Benders:");
                            foreach (var bender in earthNation.EarthBenders)
                            {
                                sb.AppendLine(bender.ToString());
                            }
                        }
                        else
                        {
                            sb.AppendLine("Benders: None");
                        }
                        if (earthNation.EarthMonuments.Count != 0)
                        {
                            sb.AppendLine("Monuments:");
                            foreach (var monument in earthNation.EarthMonuments)
                            {
                                sb.AppendLine(monument.ToString());
                            }
                        }
                        else
                        {
                            sb.AppendLine("Monuments: None");
                        }

                    }
                    break;
                case "Water":
                    {
                        sb.AppendLine("Water Nation");

                        if (waterNation.WaterBenders.Count != 0)
                        {
                            sb.AppendLine("Benders:");
                            foreach (var bender in waterNation.WaterBenders)
                            {
                                sb.AppendLine(bender.ToString());
                            }
                        }
                        else
                        {
                            sb.AppendLine("Benders: None");
                        }
                        if (waterNation.WaterMonuments.Count != 0)
                        {
                            sb.AppendLine("Monuments:");
                            foreach (var monument in waterNation.WaterMonuments)
                            {
                                sb.AppendLine(monument.ToString());
                            }
                        }
                        else
                        {
                            sb.AppendLine("Monuments: None");
                        }

                    }
                    break;
            }

            return sb.ToString().Trim();
        }

        public void IssueWar(string nationsType)
        {
            issuedWarNation.Add(nationsType);

            int airAffinitySum = airNation.AirMonuments.Sum(x => x.AirAffinity);
            double airTotalPower = airNation.AirBenders.Sum(c => c.GetBenderTotalPower());

            int earthAffinitySum = earthNation.EarthMonuments.Sum(x => x.EarthAffinity);
            double earthTotalPower = earthNation.EarthBenders.Sum(c => c.GetBenderTotalPower());

            int fireAffinitySum = fireNation.FireMonuments.Sum(x => x.FireAffinity);
            double fireTotalPower = fireNation.FireBenders.Sum(c => c.GetBenderTotalPower());

            int waterAffinitySum = waterNation.WaterMonuments.Sum(x => x.WaterAffinity);
            double waterTotalPower = waterNation.WaterBenders.Sum(c => c.GetBenderTotalPower());


            double air = airTotalPower + ((airTotalPower / 100) * airAffinitySum);
            double earth = earthTotalPower + ((earthTotalPower / 100) * earthAffinitySum);
            double fire = fireTotalPower + ((fireTotalPower / 100) * fireAffinitySum);
            double water = waterTotalPower + ((waterTotalPower / 100) * waterAffinitySum);

            if (air > earth && air > fire && air > water)
            {
                earthNation.EarthBenders.Clear();
                earthNation.EarthMonuments.Clear();
                fireNation.FireBenders.Clear();
                fireNation.FireMonuments.Clear();
                waterNation.WaterBenders.Clear();
                waterNation.WaterMonuments.Clear();
            }
            else if (earth > air && earth > fire && earth > water)
            {
                airNation.AirBenders.Clear();
                airNation.AirMonuments.Clear();
                fireNation.FireBenders.Clear();
                fireNation.FireMonuments.Clear();
                waterNation.WaterBenders.Clear();
                waterNation.WaterMonuments.Clear();
            }
            else if (fire > air && fire > earth && fire > water)
            {
                airNation.AirBenders.Clear();
                airNation.AirMonuments.Clear();
                earthNation.EarthBenders.Clear();
                earthNation.EarthMonuments.Clear();
                waterNation.WaterBenders.Clear();
                waterNation.WaterMonuments.Clear();
            }
            else
            {
                airNation.AirBenders.Clear();
                airNation.AirMonuments.Clear();
                earthNation.EarthBenders.Clear();
                earthNation.EarthMonuments.Clear();
                fireNation.FireBenders.Clear();
                fireNation.FireMonuments.Clear();
            }

        }

        public string GetWarsRecord()
        {

            StringBuilder sb = new StringBuilder();

            int count = 1;

            foreach (var nation in issuedWarNation)
            {
                sb.AppendLine($"War {count} issued by {nation}");
                count++;
            }
            return sb.ToString().Trim();
        }
    }
}
