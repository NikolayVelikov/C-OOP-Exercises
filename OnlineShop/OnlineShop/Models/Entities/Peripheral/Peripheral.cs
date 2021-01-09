using System;

using OnlineShop.Models.Contracts;
using OnlineShop.Utilities.Messages;

namespace OnlineShop.Models.Entities.Peripheral
{
    public abstract class Peripheral : Product, IPeripheral
    {
        private string _connectionType;

        protected Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.ConnectionType = connectionType;
        }

        public string ConnectionType
        {
            get { return this._connectionType; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ConncetionTypeNullOrWhitespace);
                }
                this._connectionType = value;
            }
        }

        public override string ToString()
        {
            return base.ToString()+$" Connection Type: {this.ConnectionType}";
        }
    }
}
