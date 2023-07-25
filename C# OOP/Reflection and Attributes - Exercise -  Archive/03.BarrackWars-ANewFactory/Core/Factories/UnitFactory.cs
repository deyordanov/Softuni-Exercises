namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type type = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name == unitType);

            if (type == null)
            {
                throw new InvalidOperationException("Such unit does not exist!");
            }

            IUnit unit = Activator.CreateInstance(type) as IUnit;

            return unit;
        }
    }
}
