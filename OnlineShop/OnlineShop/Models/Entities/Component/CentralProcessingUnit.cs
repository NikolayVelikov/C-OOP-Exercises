using OnlineShop.Utilities.Constants;

namespace OnlineShop.Models.Entities.Component
{
    public class CentralProcessingUnit : Component
    {
        private const double multiplier = Multiplier.CentralProcessingUnit;
        public CentralProcessingUnit(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance*multiplier, generation)
        {
        }
    }
}
