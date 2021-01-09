using System;
using System.Text;
using System.Linq;

using EasterRace.Enumerators;
using EasterRace.Core.Contracts;
using EasterRace.Utilities.Messages;
using EasterRace.Utilities.Constants;
using EasterRace.Models.Race.Entities;
using EasterRace.Models.Race.Contracts;
using EasterRace.Models.Cars.Contracts;
using EasterRace.Models.Drivers.Entities;
using EasterRace.Models.Drivers.Contracts;
using EasterRace.Models.Repositories.Entities;
using EasterRace.Models.Repositories.Contracts;

namespace EasterRace.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<ICar> _cars;
        private IRepository<IDriver> _drivers;
        private IRepository<IRace> _race;

        public ChampionshipController()
        {
            this._cars = new CarRepository();
            this._drivers = new DriverRepository();
            this._race = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = DriverExist(driverName);
            ICar car = CarExist(carModel);

            driver.AddCar(car);

            return string.Format(OutputMessages.DriverReceivedCar, driver.Name, car.Model);
        }        

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = RaceExist(raceName);
            IDriver driver = DriverExist(driverName);

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAddedInRace, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this._cars.Models.FirstOrDefault(c=>c.Model == model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarAlreadyCreated, model));
            }
            CheckingCarType(type, model);

            ICar car = CreatingCarByReflection(type, model, horsePower);
            this._cars.Add(car);

            return string.Format(OutputMessages.CarCreated, type, model);
        }        

        public string CreateDriver(string driverName)
        {
            if (this._drivers.Models.FirstOrDefault(d=>d.Name == driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverAlreadyCreated, driverName));
            }

            IDriver driver = new Driver(driverName);
            this._drivers.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (this._race.Models.FirstOrDefault(r=>r.Name == name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceAlreadyCreated, name));
            }

            IRace race = new Race(name, laps);
            this._race.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = RaceExist(raceName);
            int minDrivers = Constants.RaceDriverMin;
            if (race.Drivers.Count < 3 )
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotStart, raceName, minDrivers));
            }
            IDriver[] drivers = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoint(race.Laps)).Take(3).ToArray();

            this._race.Remove(race);

            return Winners(drivers, race.Name);
        }

        private string Winners(IDriver[] drivers, string raceName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Winners:");
            for (int i = 1; i <= drivers.Length; i++)
            {
                string driverName = drivers[i - 1].Name;
                switch (i)
                {
                    case 1: sb.AppendLine(string.Format(OutputMessages.FirstDriver, driverName, raceName));break;
                    case 2: sb.AppendLine(string.Format(OutputMessages.SecondDriver, driverName, raceName));break;
                    case 3: sb.AppendLine(string.Format(OutputMessages.ThirdDriver, driverName, raceName));break;
                }
            }

            return sb.ToString().TrimEnd();
        }
        private ICar CreatingCarByReflection(string type, string model, int horsePower)
        {
            Type carType = Type.GetType($"EasterRace.Models.Cars.Entities.{type}");

            ICar car = (ICar)Activator.CreateInstance(carType, new object[] { model, horsePower });

            return car;
        }
        private static void CheckingCarType(string type, string model)
        {
            CarEnum temp;
            if (!Enum.TryParse(type, out temp))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarTypeWrong, model));
            }
        }
        private IDriver DriverExist(string driverName)
        {
            IDriver driver = this._drivers.Models.FirstOrDefault(d => d.Name == driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            return driver;
        }
        private ICar CarExist(string carModel)
        {
            ICar car = this._cars.Models.FirstOrDefault(c => c.Model == carModel);
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            return car;
        }
        private IRace RaceExist(string raceName)
        {
            IRace race = this._race.Models.FirstOrDefault(r => r.Name == raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            return race;
        }
    }
}
