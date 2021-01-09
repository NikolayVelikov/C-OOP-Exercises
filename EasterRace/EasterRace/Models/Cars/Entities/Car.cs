using EasterRace.Models.Cars.Contracts;
using EasterRace.Utilities.Constants;
using EasterRace.Utilities.Messages;
using System;

namespace EasterRace.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int minLength = Constants.ModelMinLength;

        private string _model;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.HorsePower = CheckingHorsePower(horsePower, minHorsePower, maxHorsePower);
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get { return this._model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < minLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ModelNullWhiteSpaceOrMinLength, value, minLength));
                }
                this._model = value;
            }
        }

        public int HorsePower { get; private set; }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoint(int laps)
        {
            double points = this.CubicCentimeters / (this.HorsePower * laps);

            return points;
        }

        private int CheckingHorsePower(int value, int min, int max)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(string.Format(ExceptionMessages.HorsePowerInvalid, value));
            }
            
            return value;
        }
    }
}
