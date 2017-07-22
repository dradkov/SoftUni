using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Car
{
    private string model;
    private string engine;
    private double weight;
    private string color;


    public Car(string model, string engine, double weight, string color)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;

    }


    public string Model
    {
        get { return this.model; }
        set { this.model = value; }

    }
    public string Engine
    {
        get { return this.engine; }
        set { this.engine = value; }

    }
    public double Weight
    {
        get { return this.weight; }
        set { this.weight = value; }

    }
    public string Color
    {
        get { return this.color; }
        set { this.color = value; }

    }
}

