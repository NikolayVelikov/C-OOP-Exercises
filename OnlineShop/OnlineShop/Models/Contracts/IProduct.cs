namespace OnlineShop.Models.Contracts
{
    public interface IProduct
    {
        int Id { get; }
        string Manufacturer { get; }
        string Model { get; }
        decimal Price { get; }
        double OverallPerformance { get; }
    }
}
