using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    public interface IEmployee
    {
        string Name { get; }

        int WorkHoursPerWeek { get; }
    }
}
