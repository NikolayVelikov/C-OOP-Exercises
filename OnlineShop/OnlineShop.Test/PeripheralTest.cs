using System;

using NUnit.Framework;

using OnlineShop.Models.Contracts;
using OnlineShop.Utilities.Messages;
using OnlineShop.Models.Entities.Peripheral;

namespace OnlineShop.Test
{
    [TestFixture]
    class PeripheralTest
    {
        [Test]
        [TestCase("Headset", 1, "ASUS", "Dragon", 350.55, 1500.153, "USB-C")]
        [TestCase("Keyboard", 1, "ASUS", "Dragon", 350.55, 1500.153, "Bluetooth")]
        [TestCase("Monitor", 1, "ASUS", "Dragon", 350.55, 1500.153, "HMI or HMR")]
        [TestCase("Mouse", 1, "ASUS", "Dragon", 350.55, 1500.153, "Bluetooth")]
        public void CheckingConstructorsAndPrintingOnTheConsole(string type, int id, string manufacturer, string model, decimal price, double overall, string connectionType)
        {
            string expectedMSG = $"Overall Performance: {overall}. Price: {price:f2} - {type}: {manufacturer} {model} (Id: {id}) Connection Type: {connectionType}";

            IPeripheral pheripheral = CreatingPheripheral(type, id, manufacturer, model, price, overall, connectionType);
            string actualMSG = pheripheral.ToString();

            Assert.AreEqual(type, pheripheral.GetType().Name);
            Assert.AreEqual(id, pheripheral.Id);
            Assert.AreEqual(manufacturer, pheripheral.Manufacturer);
            Assert.AreEqual(model, pheripheral.Model);
            Assert.AreEqual(price, pheripheral.Price);
            Assert.AreEqual(overall , pheripheral.OverallPerformance);
            Assert.AreEqual(connectionType, pheripheral.ConnectionType);
            Assert.AreEqual(expectedMSG, actualMSG);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("   ")]
        public void ThrowingExceptionWhenConnectingTypeIsNullOrWhiteSpace(string connectType)
        {
            string expectingMSG = ExceptionMessages.ConncetionTypeNullOrWhitespace;

            string actualMSG = string.Empty;
            try
            {
                IPeripheral pheripheral = new Headset(1, "X", "XXX", 350.25m, 1500, connectType);
            }
            catch (ArgumentException ae)
            {
                actualMSG = ae.Message;
            }

            Assert.AreEqual(expectingMSG, actualMSG);
        }
        
        private IPeripheral CreatingPheripheral(string type, int id, string manufacturer, string model, decimal price, double overall, string connectionType)
        {
            switch (type)
            {
                case "Headset": return new Headset(id, manufacturer, model, price, overall, connectionType);
                case "Keyboard": return new Keyboard(id, manufacturer, model, price, overall, connectionType);
                case "Monitor": return new Monitor(id, manufacturer, model, price, overall, connectionType);
                case "Mouse": return new Mouse(id, manufacturer, model, price, overall, connectionType);
                default: return null;
            }
        }
    }
}
