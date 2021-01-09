using OnlineShop.Utilities.Constants;

namespace OnlineShop.Models.Entities.Component
{
   public class RandomAccessMemory:Component
    {
        private const double multiplier = Multiplier.RandomAccessMemory;
        public RandomAccessMemory(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance * multiplier, generation)
        {
        }
    }
}
