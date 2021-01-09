using System;
using System.Collections.Generic;

using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using RobotService.Utilities.Constants;

namespace RobotService.Models.Entities.Garage
{
    public class Garage : IGarage
    {
        private const int capacity = Constants.Capacity;
        private IDictionary<string, IRobot> _robots;

        public Garage()
        {
            this._robots = new Dictionary<string, IRobot>();
        }

        public int Capacity => capacity;

        public IReadOnlyDictionary<string, IRobot> Robots => (IReadOnlyDictionary<string, IRobot>)this._robots;

        public void Manufacture(IRobot robot)
        {
            if (this._robots.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.CapacityIsFull);
            }
            
            if (this._robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RobotAlreadyExist, robot.Name));
            }

            this._robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string owner)
        {
            IRobot robot = RobotExist(robotName);

            robot.Owner = owner;
            robot.IsBought = true;

            this._robots.Remove(robotName);
        }

        private IRobot RobotExist(string robotName)
        {
            if (!this._robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RobotNotExist, robotName));               
            }

            return this._robots[robotName];
        }
    }
}
