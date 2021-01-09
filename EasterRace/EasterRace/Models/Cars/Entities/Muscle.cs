using EasterRace.Utilities.Constants;

namespace EasterRace.Models.Cars.Entities
{
    public class Muscle : Car
    {
        private const double cubicCentimeters = Constants.MuscleCarCubicCentimeter;
        private const int minHorsePower = Constants.MuscleCarMinHoresePower;
        private const int maxHorsePower = Constants.MuscleCarMaxHoresePower;
        public Muscle(string model, int horsePower) : base(model, horsePower, cubicCentimeters, minHorsePower, maxHorsePower)
        {
        }
    }
}
