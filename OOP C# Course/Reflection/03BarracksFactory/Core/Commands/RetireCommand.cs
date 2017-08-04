using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitfactory) : base(data, repository, unitfactory)
        {

        }

        public override string Execute()
        {
            var unitType = Data[1];
            this.Repository.RemoveUnit(unitType);


            return $"{unitType} retired!";
        }
    }
}
