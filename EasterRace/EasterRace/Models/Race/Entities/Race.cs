using System;
using System.Linq;
using System.Collections.Generic;

using EasterRace.Utilities.Messages;
using EasterRace.Utilities.Constants;
using EasterRace.Models.Race.Contracts;
using EasterRace.Models.Drivers.Contracts;

namespace EasterRace.Models.Race.Entities
{
    public class Race : IRace
    {
        private const int minLength = Constants.RaceNameMinLength;
        private const int minLaps = Constants.LapsMin;

        private string _name;
        private int _laps;
        private IList<IDriver> _drivers;

        private Race()
        {
            this._drivers = new List<IDriver>();
        }
        public Race(string name, int laps)
            : this()
        {
            this.Name = name;
            this.Laps = laps;
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

        public int Laps
        {
            get { return this._laps; }
            private set
            {
                if (value < minLaps)
                {
                    throw new ArgumentOutOfRangeException(string.Format(ExceptionMessages.LapsLessThanMin, minLaps));
                }
                this._laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => (IReadOnlyCollection<IDriver>)this._drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverNull);
            }
            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverCannotParticipate, driver.Name));
            }
            if (this._drivers.FirstOrDefault(d => d.Name == driver.Name) != null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlredyExistInTheRace, driver.Name, this.Name));
            }

            this._drivers.Add(driver);
        }
    }
}
