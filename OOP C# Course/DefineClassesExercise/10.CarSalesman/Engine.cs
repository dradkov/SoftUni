using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Engine
{
    private string engines;
    private double power;
    private double displacement;
    private string efficiency;


    public Engine(string engines, double power, double displacement, string efficiency)
    {
        this.Engines = engines;
        this.Power = power;
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }

    public string Engines
    {
        get { return this.engines; }
        set { this.engines = value; }

    }
    public double Power
    {
        get { return this.power; }
        set { this.power = value; }

    }
    public double Displacement
    {
        get { return this.displacement; }
        set { this.displacement = value; }

    }
    public string Efficiency
    {
        get { return this.efficiency; }
        set { this.efficiency = value; }

    }
}

