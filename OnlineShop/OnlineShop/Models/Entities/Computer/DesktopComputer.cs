using OnlineShop.Utilities.Constants;

namespace OnlineShop.Models.Entities.Computer
{
    public class DesktopComputer : Computer
    {
        private const double defaultOverall = DefaultOverall.DesctopComputer;
        public DesktopComputer(int id, string manufacturer, string model, decimal price) : base(id, manufacturer, model, price, defaultOverall)
        {
        }
    }
}
