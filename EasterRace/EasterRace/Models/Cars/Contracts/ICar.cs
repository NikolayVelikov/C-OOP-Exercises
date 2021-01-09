namespace EasterRace.Models.Cars.Contracts
{
    public interface ICar
    {
        string Model { get; }
        int HorsePower { get; }
        double CubicCentimeters { get; }

        double CalculateRacePoint(int laps);
    }
}
