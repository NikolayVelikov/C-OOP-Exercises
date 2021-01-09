using System;

using RobotService.Core.Contracts;
using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using RobotService.Models.Entities.Robots;
using RobotService.Models.Entities.Garage;
using RobotService.Models.Entities.Procedures;

namespace RobotService.Core.Entities
{
    public class Controller : IController
    {
        private IProcedure _charge;
        private IProcedure _chip;
        private IProcedure _polish;
        private IProcedure _rest;
        private IProcedure _techCheck;
        private IProcedure _work;
        private IGarage _garage;

        public Controller()
        {
            this._charge = new Charge();
            this._chip = new Chip();
            this._polish = new Polish();
            this._rest = new Rest();
            this._techCheck = new TechCheck();
            this._work = new Work();
            this._garage = new Garage();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = CreatingRobot(robotType, name, energy, happiness, procedureTime);
            this._garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotRegistered, name);
        }

        public string Charge(string name, int procedureTime)
        {
            IRobot robot = RobotExist(name);
            this._charge.DoService(robot, procedureTime);

            return string.Format(OutputMessages.RobotCharge, name);
        }

        public string Chip(string name, int procedureTime)
        {
            IRobot robot = RobotExist(name);
            this._chip.DoService(robot, procedureTime);

            return string.Format(OutputMessages.RobotChipped, name);
        }

        public string History(string procedureType)
        {
            switch (procedureType)
            {
                case "Charge": return this._charge.History();
                case "Chip": return this._chip.History();
                case "Polish": return this._polish.History();
                case "Rest": return this._rest.History();
                case "TechCheck": return this._techCheck.History();
                case "Work": return this._work.History();
                default: return null;
            }
        }

        public string Polish(string name, int procedureTime)
        {
            IRobot robot = RobotExist(name);
            this._polish.DoService(robot, procedureTime);

            return string.Format(OutputMessages.RobotPolish, name);
        }

        public string Rest(string name, int procedureTime)
        {
            IRobot robot = RobotExist(name);
            this._rest.DoService(robot, procedureTime);

            return string.Format(OutputMessages.RobotRest, name);
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = RobotExist(robotName);

            this._garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                return string.Format(OutputMessages.RobotSellWithChip, robot.Owner);
            }
            else
            {
                return string.Format(OutputMessages.RobotSellWithoutChip, robot.Owner);
            }
        }

        public string TechCheck(string name, int procedureTime)
        {
            IRobot robot = RobotExist(name);
            this._techCheck.DoService(robot, procedureTime);

            return string.Format(OutputMessages.RobotTechCheck, name);
        }

        public string Work(string name, int procedureTime)
        {
            IRobot robot = RobotExist(name);
            this._work.DoService(robot, procedureTime);

            return string.Format(OutputMessages.RobotWork, name, procedureTime);
        }

        private IRobot RobotExist(string robotName)
        {
            if (!this._garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RobotNotExist, robotName));
            }

            return this._garage.Robots[robotName];
        }

        private IRobot CreatingRobot(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            switch (robotType)
            {
                case "HouseholdRobot": return new HouseholdRobot(name, energy, happiness, procedureTime);
                case "PetRobot": return new PetRobot(name, energy, happiness, procedureTime);
                case "WalkerRobot": return new WalkerRobot(name, energy, happiness, procedureTime);
                default: throw new ArgumentException(string.Format(ExceptionMessages.RobotTypeNotExist, robotType));
            }
        }
    }
}
