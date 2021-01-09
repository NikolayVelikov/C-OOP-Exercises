using OnlineShop.Utilities.Constants;

namespace OnlineShop.Models.Entities.Computer
{
    public class Laptop : Computer
    {
        private const double defaultOverall = DefaultOverall.Laptop;
        public Laptop(int id, string manufacturer, string model, decimal price) : base(id, manufacturer, model, price, defaultOverall)
        {
        }
    }
}
