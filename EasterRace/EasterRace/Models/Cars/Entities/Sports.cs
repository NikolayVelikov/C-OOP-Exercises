using EasterRace.Utilities.Constants;

namespace EasterRace.Models.Cars.Entities
{
    public class Sports : Car
    {
        private const double cubicCentimeters = Constants.SportCarCubicCentimeter;
        private const int minHorsePower = Constants.SportCarMinHoresePower;
        private const int maxHorsePower = Constants.SportCarMaxHoresePower;
        public Sports(string model, int horsePower) : base(model, horsePower, cubicCentimeters, minHorsePower, maxHorsePower)
        {
        }
    }
}
