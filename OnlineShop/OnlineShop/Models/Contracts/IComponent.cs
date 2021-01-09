namespace OnlineShop.Models.Contracts
{
   public interface IComponent : IProduct
    {
        int Generation { get; }
    }
}
