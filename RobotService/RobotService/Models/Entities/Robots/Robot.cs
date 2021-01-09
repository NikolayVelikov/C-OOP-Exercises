using System;

using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using RobotService.Utilities.Constants;

namespace RobotService.Models.Entities.Robots
{
    public abstract class Robot : IRobot
    {
        private const string firstOwner = Constants.DefaultRobotOwner;
        private int _happines;
        private int _energy;

        private Robot()
        {
            this.Owner = firstOwner;
            this.IsBought = false;
            this.IsChipped = false;
            this.IsChecked = false;
        }
        protected Robot(string name, int energy, int happiness, int procedureTime)
            :this()
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
        }

        public string Name { get; private set; }

        public int Happiness
        {
            get { return this._happines; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.HappinesNotLessZeroOrBigger100);
                }
                this._happines = value;
            }
        }

        public int Energy
        {
            get { return this._energy; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.EnergyNotLessZeroOrBigger100);
                }
                this._energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsBought { get; set; }

        public bool IsChipped { get; set; }

        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
