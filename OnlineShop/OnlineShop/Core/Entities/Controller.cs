using OnlineShop.Core.Contracts;
using OnlineShop.Enums;
using OnlineShop.Models.Contracts;
using OnlineShop.Models.Entities.Component;
using OnlineShop.Models.Entities.Computer;
using OnlineShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core.Entities
{
    public class Controller : IController
    {
        private IList<IComputer> _computers;
        private IList<IComponent> _components;
        private IList<IPeripheral> _peripherals;

        public Controller()
        {
            this._computers = new List<IComputer>();
            this._components = new List<IComponent>();
            this._peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this._computers.FirstOrDefault(pc => pc.Id == id) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ComputerIdAlreadyExist, id));
            }
            ComputerEnum com;
            if (!Enum.TryParse<ComputerEnum>(computerType, out com))
            {
                throw new ArgumentException(ExceptionMessages.ComputerTypeIsInvalid);
            }

            Type type = Type.GetType($"OnlineShop.Models.Entities.Computer.{computerType}");
            IComputer computer = (IComputer)Activator.CreateInstance(type, new object[] { id, manufacturer, model, price });

            this._computers.Add(computer);
            return string.Format(OutputMessages.ComputerCreated, id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer computer = ComputerExist(computerId);

            if (this._components.FirstOrDefault(c => c.Id == id) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ComponentIdAlreadyExist, id));
            }

            ComponentsEnum comp;
            if (!Enum.TryParse<ComponentsEnum>(componentType, out comp))
            {
                throw new ArgumentException(ExceptionMessages.ComponentTypeIsInvalid);
            }

            Type type = Type.GetType($"OnlineShop.Models.Entities.Component.{componentType}");
            IComponent component = (IComponent)Activator.CreateInstance(type, new object[] { id, manufacturer, model, price, overallPerformance, generation });

            computer.AddComponent(component);
            this._components.Add(component);

            return string.Format(OutputMessages.ComponentCreated, componentType, id, computerId);
        }

        public string AddPeripheral(int computerId, int id, string pheripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = ComputerExist(computerId);

            if (this._peripherals.FirstOrDefault(p => p.Id == id) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PeripheralIdAlreadyExist, id));
            }

            PeripheralEnum per;
            if (!Enum.TryParse<PeripheralEnum>(pheripheralType, out per))
            {
                throw new ArgumentException(ExceptionMessages.PeripheralTypeIsInvalid);
            }

            Type type = Type.GetType($"OnlineShop.Models.Entities.Peripheral.{pheripheralType}");
            IPeripheral peripheral = (IPeripheral)Activator.CreateInstance(type, new object[] { id, manufacturer, model, price, overallPerformance, connectionType });

            computer.AddPeripheral(peripheral);
            this._peripherals.Add(peripheral);

            return string.Format(OutputMessages.PeripheralCreated, pheripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = this._computers.OrderByDescending(pc => pc.OverallPerformance).ThenByDescending(pc => pc.Price).FirstOrDefault(pc => pc.Price <= budget);

            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ComputerBudgetBigOrMiss, budget)) ;
            }

            this._computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer computer = ComputerExist(id);
            this._computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = ComputerExist(id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = ComputerExist(computerId);

            IComponent component = computer.RemoveComponent(componentType);
            this._components.Remove(component);

            return string.Format(OutputMessages.ComponentRemoved, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = ComputerExist(computerId);

            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);
            this._peripherals.Remove(peripheral);

            return string.Format(OutputMessages.PeripheraltRemoved, peripheralType, peripheral.Id);
        }

        private IComputer ComputerExist(int computerId)
        {
            IComputer computer = this._computers.FirstOrDefault(pc => pc.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ComputerNotExist, computerId));
            }

            return computer;
        }
    }
}
