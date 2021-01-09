namespace RobotService.Core.Contracts
{
    public interface IController
    {
        string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime);
        string Chip(string name, int procedureTime);
        string TechCheck(string name, int procedureTime);
        string Rest(string name, int procedureTime);
        string Work(string name, int procedureTime);
        string Charge(string name, int procedureTime);
        string Polish(string name, int procedureTime);
        string Sell(string robotname, string ownerName);
        string History(string procedureType);
    }
}
