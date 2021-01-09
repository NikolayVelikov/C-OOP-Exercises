using RobotService.Core.Contracts;

namespace RobotService.Core.Entities
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IController _controller;

        public CommandInterpreter(IController controller)
        {
            this._controller = controller;
        }
        
        public string Manufacture(string[] input)
        {
            string robotType = input[0];
            string name = input[1];
            int energy = int.Parse(input[2]);
            int happiness = int.Parse(input[3]);
            int procedureTime = int.Parse(input[4]);

            return this._controller.Manufacture(robotType, name, energy, happiness, procedureTime);
        }

        public string Charge(string[] input)
        {
            string robotName = input[0];
            int procedureTime = int.Parse(input[1]);

            return this._controller.Charge(robotName, procedureTime);
        }

        public string Chip(string[] input)
        {
            string robotName = input[0];
            int procedureTime = int.Parse(input[1]);

           return this._controller.Chip(robotName, procedureTime);
        }

        public string History(string[] input)
        {
            string procedureType = input[0];

            return this._controller.History(procedureType);
        }

        public string Polish(string[] input)
        {
            string robotName = input[0];
            int procedureTime = int.Parse(input[1]);

            return this._controller.Polish(robotName, procedureTime);
        }

        public string Rest(string[] input)
        {
            string robotName = input[0];
            int procedureTime = int.Parse(input[1]);

            return this._controller.Rest(robotName, procedureTime);
        }

        public string Sell(string[] input)
        {
            string robotName = input[0];
            string owner = input[1];

            return this._controller.Sell(robotName, owner);
        }

        public string TechCheck(string[] input)
        {
            string robotName = input[0];
            int procedureTime = int.Parse(input[1]);

            return this._controller.TechCheck(robotName, procedureTime);
        }

        public string Work(string[] input)
        {
            string robotName = input[0];
            int procedureTime = int.Parse(input[1]);

            return this._controller.Work(robotName, procedureTime);
        }
    }
}
