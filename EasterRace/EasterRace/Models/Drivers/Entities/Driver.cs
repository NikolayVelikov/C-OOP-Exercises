using System;

using EasterRace.Utilities.Messages;
using EasterRace.Utilities.Constants;
using EasterRace.Models.Cars.Contracts;
using EasterRace.Models.Drivers.Contracts;

namespace EasterRace.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int minLength = Constants.DriverNameMinLength;

        private string _name;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this._name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < minLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullWhiteSpaceOrMinLength, value, minLength));
                }
                this._name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => Practise();        

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarNull);
            }

            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        private bool Practise()
        {
            if (this.Car != null)
            {
                return true;
            }

            return false;
        }
    }
}
