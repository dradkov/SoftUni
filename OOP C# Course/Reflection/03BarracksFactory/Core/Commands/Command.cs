namespace _03BarracksFactory.Core.Commands
{
    using System;
    using _03BarracksFactory.Contracts;

 
    public abstract class  Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitfactory;


        public Command(string[] data, IRepository repository, IUnitFactory unitfactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.Unitfactory = unitfactory;
        }

        protected string[] Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }
        protected IRepository Repository
        {
            get { return this.repository; }
            private set { this.repository = value; }
        }
        protected IUnitFactory Unitfactory
        {
            get { return this.unitfactory; }
            private set { this.unitfactory = value; }
        }


        public abstract string Execute();

    }
}
