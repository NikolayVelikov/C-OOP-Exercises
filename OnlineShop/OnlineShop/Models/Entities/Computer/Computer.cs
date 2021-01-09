using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using OnlineShop.Models.Contracts;
using OnlineShop.Utilities.Messages;

namespace OnlineShop.Models.Entities.Computer
{
    public abstract class Computer : Product, IComputer
    {
        private IList<IComponent> _components;
        private IList<IPeripheral> _pheripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            this._components = new List<IComponent>();
            this._pheripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)this._components;

        public IReadOnlyCollection<IPeripheral> Pheripheral => (IReadOnlyCollection<IPeripheral>)this._pheripherals;

        public override double OverallPerformance
        {
            get
            {
                if (this._components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                return base.OverallPerformance + this._components.Average(c => c.OverallPerformance);
            }
        }

        public override decimal Price
        {
            get
            {
                return base.Price + this._components.Sum(c => c.Price) + this._pheripherals.Sum(p => p.Price);
            }
        }

        public void AddComponent(IComponent component)
        {
            if (this._components.FirstOrDefault(c=>c.GetType().Name == component.GetType().Name) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ComponentAlreadyExist, component.GetType().Name, base.GetType().Name, base.Id));
            }

            this._components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this._pheripherals.FirstOrDefault(p => p.GetType().Name == peripheral.GetType().Name) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PeripheralAlreadyExist, peripheral.GetType().Name, base.GetType().Name, base.Id));
            }

            this._pheripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = this._components.FirstOrDefault(c => c.GetType().Name == componentType);
            if (component == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ComponentNotExist, componentType, base.GetType().Name, base.Id));
            }

            this._components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral pheripheral = this._pheripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);
            if (pheripheral == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PeripheralNotExist, peripheralType, base.GetType().Name, base.Id));
            }

            this._pheripherals.Remove(pheripheral);

            return pheripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            sb.AppendLine($" Components ({this._components.Count}):");
            foreach (IComponent component in this._components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }

            double average = 0;
            if (this._pheripherals.Count > 0)
            {
                average = this._pheripherals.Average(p => p.OverallPerformance);
            }
            sb.AppendLine($" Peripherals({this._pheripherals.Count}); Average Overall Performance({average}):");
            foreach (IPeripheral peripheral in this._pheripherals)
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
