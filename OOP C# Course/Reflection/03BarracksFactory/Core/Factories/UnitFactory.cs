using System.Reflection;
using _03BarracksFactory.Models.Units;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {

            var type = Type.GetType("_03BarracksFactory.Models.Units." + unitType);

            var constructor =
                 type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, Type.EmptyTypes, null);

            IUnit unit = (IUnit)constructor.Invoke(new object[] { });

            return unit;
        }
    }
}
