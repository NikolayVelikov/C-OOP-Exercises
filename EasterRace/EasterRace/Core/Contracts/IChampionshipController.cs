namespace EasterRace.Core.Contracts
{
    public interface IChampionshipController
    {
        string CreateDriver(string driverName);
        string CreateCar(string type, string model, int horsePower);
        string CreateRace(string name, int laps);
        string AddCarToDriver(string driverName, string carModel);
        string AddDriverToRace(string raceName, string driverName);
        string StartRace(string raceName);
    }
}
