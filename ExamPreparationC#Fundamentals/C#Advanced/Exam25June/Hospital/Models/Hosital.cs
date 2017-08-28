using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public abstract class Hosital
    {
        public Hosital(int numberOfRooms, int beds)
        {
            this.NumberOfRooms = numberOfRooms;
            this.Beds = beds;
        }



        public int NumberOfRooms { get; set; }

        public int Beds { get; set; }
    }
}
