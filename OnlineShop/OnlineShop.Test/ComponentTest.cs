using System;

using NUnit.Framework;

using OnlineShop.Models.Contracts;
using OnlineShop.Models.Entities.Component;
using OnlineShop.Utilities.Messages;

namespace OnlineShop.Test
{
    [TestFixture]
    class ComponentTest
    {
        [Test]
        [TestCase("CentralProcessingUnit", 1, "ASUS", "Dragon", 350.55, 1500.153, 15)]
        [TestCase("Motherboard", 1, "ASUS", "Dragon", 350.55, 1500.153, 15)]
        [TestCase("PowerSupply", 1, "ASUS", "Dragon", 350.55, 1500.153, 15)]
        [TestCase("RandomAccessMemory", 1, "ASUS", "Dragon", 350.55, 1500.153, 15)]
        [TestCase("SolidStateDrive", 1, "ASUS", "Dragon", 350.55, 1500.153, 15)]
        [TestCase("VideoCard", 1, "ASUS", "Dragon", 350.55, 1500.153, 15)]
        public void CheckingConstructorsAndPrintingOnTheConsole(string type, int id, string manufacturer, string model, decimal price, double overall, int generation)
        {
            double multiplier = Multiplier(type);
            string expectedMSG = $"Overall Performance: {overall * multiplier}. Price: {price:f2} - {type}: {manufacturer} {model} (Id: {id}) Generation: {generation}";

            IComponent component = CreatingComponent(type, id, manufacturer, model, price, overall, generation);
            string actualMSG = component.ToString();

            Assert.AreEqual(type, component.GetType().Name);
            Assert.AreEqual(id, component.Id);
            Assert.AreEqual(manufacturer, component.Manufacturer);
            Assert.AreEqual(model, component.Model);
            Assert.AreEqual(price, component.Price);
            Assert.AreEqual(overall * multiplier, component.OverallPerformance);
            Assert.AreEqual(generation, component.Generation);
            Assert.AreEqual(expectedMSG, actualMSG);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(null)]
        public void IdThrowsExeptionWhenItIsNullOrZero(int id)
        {
            string expectedMSG = ExceptionMessages.IdEqualOrLessThanZero;
            string actualMSG = string.Empty;
            try
            {
                IComponent component = new CentralProcessingUnit(id, "X", "XXX", 152.5m, 163, 3);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                actualMSG = aore.ParamName;
            }

            Assert.AreEqual(expectedMSG, actualMSG);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(null)]
        public void PriceThrowsExeptionWhenItIsNullOrZero(decimal price)
        {
            string expectedMSG = ExceptionMessages.PriceEqualOrLessThanZero;
            string actualMSG = string.Empty;
            try
            {
                IComponent component = new CentralProcessingUnit(15, "X", "XXX", price, 163, 3);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                actualMSG = aore.ParamName;
            }

            Assert.AreEqual(expectedMSG, actualMSG);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(null)]
        public void OverallPerformanceThrowsExeptionWhenItIsNullOrZero(double overall)
        {
            string expectedMSG = ExceptionMessages.OverallPerformanceEqualOrLessThanZero;
            string actualMSG = string.Empty;
            try
            {
                IComponent component = new CentralProcessingUnit(15, "X", "XXX", 153.3M, overall, 3);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                actualMSG = aore.ParamName;
            }

            Assert.AreEqual(expectedMSG, actualMSG);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(null)]
        public void GenerationThrowsExeptionWhenItIsNullOrZero(int generation)
        {
            string expectedMSG = ExceptionMessages.GenerationEqualOrLessThanZero;
            string actualMSG = string.Empty;
            try
            {
                IComponent component = new CentralProcessingUnit(15, "X", "XXX", 153.03m, 163, generation);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                actualMSG = aore.ParamName;
            }

            Assert.AreEqual(expectedMSG, actualMSG);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("   ")]
        public void ManufacturerThrowsExeptionWhenItIsNullOrWhiteSpace(string manufacturer)
        {
            string expectedMSG = ExceptionMessages.ManufacturerNullOrWhitespace;
            string actualMSG = string.Empty;
            try
            {
                IComponent component = new CentralProcessingUnit(15, manufacturer, "XXX", 153.3m, 163, 3);
            }
            catch (ArgumentException ae)
            {
                actualMSG = ae.Message;
            }

            Assert.AreEqual(expectedMSG, actualMSG);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("   ")]
        public void ModelThrowsExeptionWhenItIsNullOrWhiteSpace(string model)
        {
            string expectedMSG = ExceptionMessages.ModelNullOrWhitespace;
            string actualMSG = string.Empty;
            try
            {
                IComponent component = new CentralProcessingUnit(15, "X", model, 153.3m, 163, 3);
            }
            catch (ArgumentException ae)
            {
                actualMSG = ae.Message;
            }

            Assert.AreEqual(expectedMSG, actualMSG);
        }

        private double Multiplier(string type)
        {
            double multiplier = 0;
            switch (type)
            {
                case "CentralProcessingUnit": multiplier = 1.25; break;
                case "Motherboard": multiplier = 1.25; break;
                case "PowerSupply": multiplier = 1.05; break;
                case "RandomAccessMemory": multiplier = 1.20; break;
                case "SolidStateDrive": multiplier = 1.20; break;
                case "VideoCard": multiplier = 1.15; break;
            }

            return multiplier;
        }
        private IComponent CreatingComponent(string type, int id, string manufacturer, string model, decimal price, double overall, int generation)
        {
            switch (type)
            {
                case "CentralProcessingUnit": return new CentralProcessingUnit(id, manufacturer, model, price, overall, generation);
                case "Motherboard": return new Motherboard(id, manufacturer, model, price, overall, generation);
                case "PowerSupply": return new PowerSupply(id, manufacturer, model, price, overall, generation);
                case "RandomAccessMemory": return new RandomAccessMemory(id, manufacturer, model, price, overall, generation);
                case "SolidStateDrive": return new SolidStateDrive(id, manufacturer, model, price, overall, generation);
                case "VideoCard": return new VideoCard(id, manufacturer, model, price, overall, generation);
                default: return null;
            }
        }
    }
}
