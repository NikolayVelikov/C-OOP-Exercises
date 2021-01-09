using System.Collections.Generic;

namespace OnlineShop.Models.Contracts
{
    public interface IComputer : IProduct
    {
        IReadOnlyCollection<IComponent> Components { get; }
        IReadOnlyCollection<IPeripheral> Pheripheral { get; }
        void AddComponent(IComponent component);
        IComponent RemoveComponent(string componentType);
        void AddPeripheral(IPeripheral peripheral);
        IPeripheral RemovePeripheral(string peripheralType);
    }
}
