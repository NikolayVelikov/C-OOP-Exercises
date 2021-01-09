namespace EasterRace.Core.Contracts
{
    public interface IComandInterpreter
    {
        string CreateDriver(string[] input);
        string CreateCar(string[] input);
        string CreateRace(string[] input);
        string AddCarToDriver(string[] input);
        string AddDriverToRace(string[] input);
        string StartRace(string[] input);
    }
}
