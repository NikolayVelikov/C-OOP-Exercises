using OnlineShop.Utilities.Constants;

namespace OnlineShop.Models.Entities.Component
{
   public class VideoCard:Component
    {
        private const double multiplier = Multiplier.VideoCard;
        public VideoCard(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance * multiplier, generation)
        {
        }
    }
}
