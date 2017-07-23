using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumption;// liters per km
    private double tankCapacity;


    public Vehicle(double fuelQuantity, double fuelConsumption,double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
        this.TankCapacity = tankCapacity;
    }

    public double TankCapacity
    {
        get { return this.tankCapacity; }
        set
        {
            this.tankCapacity = value;
        }

    }


    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set
        {
            
            this.fuelQuantity = value;
        }
            
    }
    public double FuelConsumption
    {
        get { return this.fuelConsumption; }
        set
        {
            this.fuelConsumption = value;
        }

    }


    public abstract void Drive(double distance);
    public abstract void AddFuel(double fuel);
    public abstract override string ToString();



}

