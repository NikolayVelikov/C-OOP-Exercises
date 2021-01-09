using EasterRace.Core.Contracts;

namespace EasterRace.Core.Entities
{
    public class ComandInterpreter : IComandInterpreter
    {
        private IChampionshipController _controller;

        public ComandInterpreter(IChampionshipController championshipController)
        {
            this._controller = championshipController;
        }

        public string AddCarToDriver(string[] input)
        {
            string driverName = input[0];
            string carModel = input[1];

            return this._controller.AddCarToDriver(driverName, carModel);
        }

        public string AddDriverToRace(string[] input)
        {
            string raceName = input[0];
            string driverName = input[1];

            return this._controller.AddDriverToRace(raceName, driverName);
        }

        public string CreateCar(string[] input)
        {
            string type = input[0];
            string model = input[1];
            int horsePower = int.Parse(input[2]);

            return this._controller.CreateCar(type, model, horsePower);
        }

        public string CreateDriver(string[] input)
        {
            string driverName = input[0];

            return this._controller.CreateDriver(driverName);
        }

        public string CreateRace(string[] input)
        {
            string name = input[0];
            int laps = int.Parse(input[1]);

            return this._controller.CreateRace(name, laps);
        }

        public string StartRace(string[] input)
        {
            string raceName = input[0];

            return this._controller.StartRace(raceName);
        }
    }
}
