namespace RobotService.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Manufacture(string[] input);
        string Chip(string[] input);
        string TechCheck(string[] input);
        string Rest(string[] input);
        string Work(string[] input);
        string Charge(string[] input);
        string Polish(string[] input);
        string Sell(string[] input);
        string History(string[] input);
    }
}
