namespace RawData.Models
{
    using System.Collections.Generic;

    public class Car
    {

        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tyres> tyres;


        public Car(string model, Engine engine, Cargo cargo, List<Tyres> tyres)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tyres = tyres;

        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }
        public Cargo Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }
        public List<Tyres> Tyres
        {
            get { return this.tyres; }
            set { this.tyres = value; }
        }
    }
}

