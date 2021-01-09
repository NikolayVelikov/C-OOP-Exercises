using NUnit.Framework;
using OnlineShop.Models.Contracts;
using OnlineShop.Models.Entities.Component;
using OnlineShop.Models.Entities.Computer;
using OnlineShop.Models.Entities.Peripheral;
using System;

namespace OnlineShop.Test
{
    [TestFixture]
    class ComputerTest
    {
        private IComputer _computer;
        private IComponent _component;
        private IPeripheral _pheripheral;
        [SetUp]
        public void SetUp()
        {
            this._computer = new Laptop(1, "ASUS", "ROG", 2500m);
            this._component = new VideoCard(1, "ASUS", "Dragon1", 350, 1000, 15);
            this._pheripheral = new Monitor(1, "Sony", "Dragon2", 455.5m, 1000, "HDMI");
        }

        [Test]
        [TestCase("DesktopComputer", 1, "ASUS", "Dragon", 350.55)]
        [TestCase("Laptop", 1, "ASUS", "Dragon", 350.55)]
        public void Checkingconstructors(string type, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = CreatingComputer(type, id, manufacturer, model, price);
            double overall = Overall(type);

            Assert.AreEqual(type, computer.GetType().Name);
            Assert.AreEqual(id, computer.Id);
            Assert.AreEqual(manufacturer, computer.Manufacturer);
            Assert.AreEqual(model, computer.Model);
            Assert.AreEqual(price, computer.Price);
            Assert.AreEqual(0, computer.Components.Count);
            Assert.AreEqual(0, computer.Pheripheral.Count);
        }

        [Test]
        public void CheckingComputerPrice()
        {
            decimal expectingPrice = 2500 + 350 + 455.5m;

            this._computer.AddComponent(this._component);
            this._computer.AddPeripheral(this._pheripheral);
            decimal actualPrice = this._computer.Price;

            Assert.AreEqual(expectingPrice, actualPrice);
        }

        [Test]
        public void CheckingOveraLLPerformance()
        {
            double expectingOverall = 10 + this._component.OverallPerformance;

            this._computer.AddComponent(this._component);
            this._computer.AddPeripheral(this._pheripheral);

            double actualOverall = this._computer.OverallPerformance;

            Assert.AreEqual(expectingOverall, actualOverall);
        }

        [Test]
        public void ThrowingExeptionWhenComponentAlreadyExist()
        {
            string expectingMSG = $"Component {this._component.GetType().Name} already exists in {this._computer.GetType().Name} with Id {this._computer.Id}.";

            Adding();
            string actualMSG = string.Empty;

            try
            {
                this._computer.AddComponent(this._component);
            }
            catch (ArgumentException ae)
            {
                actualMSG = ae.Message;
            }

            Assert.AreEqual(expectingMSG, actualMSG);
        }

        [Test]
        public void ThrowingExeptionWhenComponentNotExist()
        {
            string expectingMSG = $"Component {"XXX"} does not exist in {this._computer.GetType().Name} with Id {this._computer.Id}.";

            Adding();
            string actualMSG = string.Empty;

            try
            {
                this._computer.RemoveComponent("XXX");
            }
            catch (ArgumentException ae)
            {
                actualMSG = ae.Message;
            }

            Assert.AreEqual(expectingMSG, actualMSG);
        }

        [Test]
        public void ThrowingExeptionWhenPheripheralAlreadyExist()
        {
            string expectingMSG = $"Peripheral {this._pheripheral.GetType().Name} already exists in {this._computer.GetType().Name} with Id {this._computer.Id}.";

            Adding();
            string actualMSG = string.Empty;

            try
            {
                this._computer.AddPeripheral(this._pheripheral);
            }
            catch (ArgumentException ae)
            {
                actualMSG = ae.Message;
            }

            Assert.AreEqual(expectingMSG, actualMSG);
        }

        [Test]
        public void ThrowingExeptionWhenPheripheralNotExist()
        {
            string expectingMSG = $"Peripheral {"XXX"} does not exist in {this._computer.GetType().Name} with Id {this._computer.Id}.";

            Adding();
            string actualMSG = string.Empty;

            try
            {
                this._computer.RemovePeripheral("XXX");
            }
            catch (ArgumentException ae)
            {
                actualMSG = ae.Message;
            }

            Assert.AreEqual(expectingMSG, actualMSG);
        }

        [Test]
        public void RemovingComponent()
        {
            Adding();

            IComponent componet = this._computer.RemoveComponent(this._component.GetType().Name);

            Assert.AreEqual(componet.GetType().Name, this._component.GetType().Name);
            Assert.AreEqual(0,this._computer.Components.Count);
        }

        [Test]
        public void RemovingPheripheral()
        {
            Adding();

            IPeripheral pheripheral = this._computer.RemovePeripheral(this._pheripheral.GetType().Name);

            Assert.AreEqual(pheripheral.GetType().Name, this._pheripheral.GetType().Name);
            Assert.AreEqual(0, this._computer.Pheripheral.Count);
        }

        private IComputer CreatingComputer(string type, int id, string manufacturer, string model, decimal price)
        {
            switch (type)
            {
                case "DesktopComputer": return new DesktopComputer(id, manufacturer, model, price);
                case "Laptop": return new Laptop(id, manufacturer, model, price);
                default: return null;
            }
        }
        private double Overall(string type)
        {
            switch (type)
            {
                case "DesktopComputer": return 15;
                case "Laptop": return 10;
                default: return 0;
            }
        }
        private void Adding()
        {
            this._computer.AddComponent(this._component);
            this._computer.AddPeripheral(this._pheripheral);
        }
    }
}
