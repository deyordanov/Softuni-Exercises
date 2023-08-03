namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common.Constants;
    using Products.Components;
    using Products.Computers;
    using Products.Peripherals;

    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();
        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();
        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(comp => comp.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name,
                    this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!this.Components.Any(comp => comp.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType,
                    this.GetType().Name, this.Id));
            }

            IComponent returnValue = this.Components.First(comp => comp.GetType().Name == componentType);
            this.components.Remove(returnValue);

            return returnValue;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(per => per.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!this.Peripherals.Any(per => per.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType,
                    this.GetType().Name, this.Id));
            }

            IPeripheral returnValue = this.Peripherals.First(per => per.GetType().Name == peripheralType);
            this.peripherals.Remove(returnValue);

            return returnValue;
        }

        public override double OverallPerformance 
        => this.Components.Count() == 0 ? base.OverallPerformance : this.Components.Count() == 0 ? 0 : this.Components.Average(component => component.OverallPerformance) + base.OverallPerformance;

        public override decimal Price 
            => base.Price + this.Components.Sum(component => component.Price) + this.Peripherals.Sum(peripheral => peripheral.Price);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.Components.Count()}):");
            foreach (IComponent component in Components)
            {
                sb.AppendLine($"  {component}");
            }

            double averagePeripheralPerformance = this.Peripherals.Count() == 0
                ? 0
                : this.Peripherals.Average(peripheral => peripheral.OverallPerformance);
            sb.AppendLine(
                $" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({averagePeripheralPerformance:F2}):");
            foreach (IPeripheral peripheral in Peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}