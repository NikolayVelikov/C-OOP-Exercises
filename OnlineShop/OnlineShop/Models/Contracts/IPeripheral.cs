namespace OnlineShop.Models.Contracts
{
    public interface IPeripheral : IProduct
    {
        string ConnectionType { get; }
    }
}
