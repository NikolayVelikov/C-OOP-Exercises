using EasterRace.Models.Cars.Contracts;

namespace EasterRace.Models.Drivers.Contracts
{
    public interface IDriver
    {
        string Name { get; }
        ICar Car { get; }
        int NumberOfWins { get; }
        bool CanParticipate { get; }

        void AddCar(ICar car);
        void WinRace();
    }
}
