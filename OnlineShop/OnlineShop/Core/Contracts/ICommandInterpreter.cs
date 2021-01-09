namespace OnlineShop.Core.Contracts
{
   public interface ICommandInterpreter
    {
        string AddComputer(string[] array);
        string AddComponent(string[] array);
        string RemoveComponent(string[] array);
        string AddPeripheral(string[] array);
        string RemovePeripheral(string[] array);
        string BuyComputer(string[] array);
        string BuyBestComputer(string[] array);
        string GetComputerData(string[] array);

    }
}
