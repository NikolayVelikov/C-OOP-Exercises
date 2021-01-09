using System;

using OnlineShop.Models.Contracts;
using OnlineShop.Utilities.Messages;

namespace OnlineShop.Models.Entities
{
    public abstract class Product : IProduct
    {
        private int _id;
        private string _manufacturer;
        private string _model;
        private decimal _price;
        private double _overallPerformance;

        protected Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get { return this._id; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(ExceptionMessages.IdEqualOrLessThanZero);
                }
                this._id = value;
            }
        }

        public string Manufacturer
        {
            get { return this._manufacturer; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ManufacturerNullOrWhitespace);
                }
                this._manufacturer = value;
            }
        }

        public string Model
        {
            get { return this._model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }
                this._model = value;
            }
        }

        public virtual decimal Price
        {
            get { return this._price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(ExceptionMessages.PriceEqualOrLessThanZero);
                }
                this._price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get { return this._overallPerformance; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(ExceptionMessages.OverallPerformanceEqualOrLessThanZero);
                }
                this._overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return $"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})";
        }
    }
}
