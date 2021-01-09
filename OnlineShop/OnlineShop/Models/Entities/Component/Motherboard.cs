using OnlineShop.Utilities.Constants;

namespace OnlineShop.Models.Entities.Component
{
    public class Motherboard : Component
    {
        private const double multiplier = Multiplier.Motherboard;
        public Motherboard(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance * multiplier, generation)
        {
        }
    }
}
