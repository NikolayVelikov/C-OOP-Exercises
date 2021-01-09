using OnlineShop.Core.Contracts;

namespace OnlineShop.Core.Entities
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IController _controller;

        public CommandInterpreter(IController controller)
        {
            this._controller = controller;
        }

        public string AddComponent(string[] array)
        {
            int computerId = int.Parse(array[0]);
            int componentId = int.Parse(array[1]);
            string componentType = array[2];
            string manufacturer = array[3];
            string model = array[4];
            decimal price = decimal.Parse(array[5]);
            double overallPerformance = double.Parse(array[6]);
            int generation = int.Parse(array[7]);

            return this._controller.AddComponent(computerId, componentId, componentType, manufacturer, model, price, overallPerformance, generation);
        }

        public string AddComputer(string[] array)
        {
            string type = array[0];
            int id = int.Parse(array[1]);
            string manufacturer = array[2];
            string model = array[3];
            decimal price = decimal.Parse(array[4]);

            return this._controller.AddComputer(type, id, manufacturer, model, price);
        }

        public string AddPeripheral(string[] array)
        {
            int computerId = int.Parse(array[0]);
            int peripheralId = int.Parse(array[1]);
            string peripheralType = array[2];
            string manufacturer = array[3];
            string model = array[4];
            decimal price = decimal.Parse(array[5]);
            double overallPerformance = double.Parse(array[6]);
            string connectionType = array[7];

            return this._controller.AddPeripheral(computerId, peripheralId, peripheralType, manufacturer, model, price, overallPerformance, connectionType);
        }

        public string BuyBestComputer(string[] array)
        {
            decimal budget = decimal.Parse(array[0]);

            return this._controller.BuyBest(budget);
        }

        public string BuyComputer(string[] array)
        {
            int id = int.Parse(array[0]);

            return this._controller.BuyComputer(id);
        }

        public string GetComputerData(string[] array)
        {
            int id = int.Parse(array[0]);

            return this._controller.GetComputerData(id);
        }

        public string RemoveComponent(string[] array)
        {
            string componentType = array[0];
            int computerId = int.Parse(array[1]);

            return this._controller.RemoveComponent(componentType, computerId);
        }

        public string RemovePeripheral(string[] array)
        {
            string peripheralType = array[0];
            int computerId = int.Parse(array[1]);

            return this._controller.RemovePeripheral(peripheralType, computerId);
        }
    }
}
