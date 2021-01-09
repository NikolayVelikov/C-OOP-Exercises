using System;

using OnlineShop.Models.Contracts;
using OnlineShop.Utilities.Messages;

namespace OnlineShop.Models.Entities.Component
{
    public abstract class Component : Product, IComponent
    {
        private int _generation;
        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.Generation = generation;
        }

        public int Generation
        {
            get { return this._generation; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(ExceptionMessages.GenerationEqualOrLessThanZero);
                }
                this._generation = value;
            }
        }

        public override string ToString()
        {
            return base.ToString()+$" Generation: {this.Generation}";
        }
    }
}
