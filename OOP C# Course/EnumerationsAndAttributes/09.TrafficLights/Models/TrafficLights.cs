using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using _09.TrafficLights.Enums;

namespace _09.TrafficLights.Models
{
    public class TrafficLights
    {

       

        public TrafficLights(string light)
        {
            this.Light = (Colors)Enum.Parse(typeof(Colors), light);
          
         
        }

        public Colors Light { get; private set; }


        public void CheckColors()
        {
            this.Light += 1;

            if ((int)this.Light > 2)
            {
                this.Light = 0;
            }
        }


        public override string ToString()
        {
            return $"{this.Light}";
        }

      
    }
}
