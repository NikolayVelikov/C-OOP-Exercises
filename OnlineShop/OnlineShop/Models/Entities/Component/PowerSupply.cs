using OnlineShop.Utilities.Constants;

namespace OnlineShop.Models.Entities.Component
{
    public class PowerSupply: Component
    {
        private const double multiplier = Multiplier.PowerSupply;
        public PowerSupply(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance * multiplier, generation)
        {
        }
    }
}
