namespace OnlineShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Common.Constants;
    using Common.Enums;

    using Models;
    using Models.Products.Components;
    using Models.Products.Computers;
    using Models.Products.Peripherals;

    public class Controller : IController
    {
        private List<IComputer> computers;

        public Controller()
        {
            this.computers = new List<IComputer>();
        }
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(pc => pc.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            bool isValid = Enum.TryParse<ComputerType>(computerType, false, out ComputerType type);
            if (!isValid)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }


            if (computerType == "DesktopComputer")
            {
                this.computers.Add(new DesktopComputer(id, manufacturer, model, price));
            }
            else if (computerType == "Laptop")
            {
                this.computers.Add(new Laptop(id, manufacturer, model, price));
            }

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            if (!this.computers.Any(pc => pc.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = this.computers.First(pc => pc.Id == computerId);

            if (computer.Peripherals.Any(per => per.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            bool isValid = Enum.TryParse<PeripheralType>(peripheralType, false, out PeripheralType type);
            if (!isValid)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            if (peripheralType == "Headset")
            {
                computer.AddPeripheral(new Headset(id, manufacturer, model, price, overallPerformance, connectionType));
            }
            else if (peripheralType == "Keyboard")
            {
                computer.AddPeripheral(new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType));
            }
            else if (peripheralType == "Monitor")
            {
                computer.AddPeripheral(new Monitor(id, manufacturer, model, price, overallPerformance, connectionType));
            }
            else if (peripheralType == "Mouse")
            {
                computer.AddPeripheral(new Mouse(id, manufacturer, model, price, overallPerformance, connectionType));
            }

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computer.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (!this.computers.Any(pc => pc.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = this.computers.First(pc => pc.Id == computerId);

            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            if (!this.computers.Any(pc => pc.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = this.computers.First(pc => pc.Id == computerId);

            if (computer.Components.Any(component => component.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            bool isValid = Enum.TryParse<ComponentType>(componentType, false, out ComponentType type);
            if (!isValid)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            if (componentType == "CentralProcessingUnit")
            {
                computer.AddComponent(new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation));
            }
            else if (componentType == "Motherboard")
            {
                computer.AddComponent(new Motherboard(id, manufacturer, model, price, overallPerformance, generation));
            }
            else if (componentType == "PowerSupply")
            {
                computer.AddComponent(new PowerSupply(id, manufacturer, model, price, overallPerformance, generation));
            }
            else if (componentType == "RandomAccessMemory")
            {
                computer.AddComponent(new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation));
            }
            else if (componentType == "SolidStateDrive")
            {
                computer.AddComponent(new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation));
            }
            else if (componentType == "VideoCard")
            {
                computer.AddComponent(new VideoCard(id, manufacturer, model, price, overallPerformance, generation));
            }

            return $"Component {componentType} with id {id} added successfully in computer with id {computer.Id}.";
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (!this.computers.Any(pc => pc.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = this.computers.First(pc => pc.Id == computerId);

            IComponent component = computer.RemoveComponent(componentType);

            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string BuyComputer(int id)
        {
            if (!this.computers.Any(pc => pc.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = this.computers.First(pc => pc.Id == id);

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            IComputer computerToBuy = this.computers.OrderByDescending(pc => pc.OverallPerformance).ThenByDescending(pc => pc.Price)
                .FirstOrDefault(pc => pc.Price <= budget);

            if (computerToBuy == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(computerToBuy);

            return computerToBuy.ToString();
        }

        public string GetComputerData(int id)
        {
            if (!this.computers.Any(pc => pc.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return this.computers.First(pc => pc.Id == id).ToString();
        }
    }
}