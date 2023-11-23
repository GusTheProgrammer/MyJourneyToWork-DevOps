namespace MyJourneyToWorkTests
{
    public class CalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConvertDistance_KilometersToMiles_ConvertsCorrectly()
        {
            var calculator = new Calculator.Calculator { distance = 10, milesOrKms = Calculator.DistanceMeasurement.kms };
            Assert.That(calculator.convertDistance(), Is.EqualTo(6.21371).Within(0.00001));
        }

        [Test]
        public void ConvertDistance_MilesToMiles_NoConversion()
        {
            var calculator = new Calculator.Calculator { distance = 10, milesOrKms = Calculator.DistanceMeasurement.miles };
            Assert.That(calculator.convertDistance(), Is.EqualTo(10));
        }

        [Test]
        public void SustainabilityWeighting_PetrolMode_CalculatesCorrectly()
        {
            var calculator = new Calculator.Calculator { transportMode = Calculator.TransportModes.petrol, distance = 10, numDays = 5 };
            double expected = 8 * 10 * (5 * 2); // Assuming the weighting for petrol is 8
            Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
        }

        [Test]
        public void SustainabilityWeighting_DieselMode_CalculatesCorrectly()
        {
            var calculator = new Calculator.Calculator { transportMode = Calculator.TransportModes.deisel, distance = 15, numDays = 3 };
            double expected = 10 * 15 * (3 * 2); // Assuming the weighting for diesel is 10
            Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
        }

        [Test]
        public void SustainabilityWeighting_HybridMode_CalculatesCorrectly()
        {
            var calculator = new Calculator.Calculator { transportMode = Calculator.TransportModes.hybrid, distance = 20, numDays = 4 };
            double expected = 6 * 20 * (4 * 2); // Assuming the weighting for hybrid is 6
            Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
        }

        [Test]
        public void SustainabilityWeighting_ElectricMode_CalculatesCorrectly()
        {
            var calculator = new Calculator.Calculator { transportMode = Calculator.TransportModes.electric, distance = 25, numDays = 2 };
            double expected = 4 * 25 * (2 * 2); // Assuming the weighting for electric is 4
            Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
        }

        [Test]
        public void SustainabilityWeighting_MotorbikeMode_CalculatesCorrectly()
        {
            var calculator = new Calculator.Calculator { transportMode = Calculator.TransportModes.motorbike, distance = 30, numDays = 1 };
            double expected = 3 * 30 * (1 * 2); // Assuming the weighting for motorbike is 3
            Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
        }

        [Test]
        public void SustainabilityWeighting_ElectricBikeMode_CalculatesCorrectly()
        {
            var calculator = new Calculator.Calculator { transportMode = Calculator.TransportModes.electricbike, distance = 35, numDays = 6 };
            double expected = 2 * 35 * (6 * 2); // Assuming the weighting for electric bike is 2
            Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
        }

        [Test]
        public void SustainabilityWeighting_TrainMode_CalculatesCorrectly()
        {
            var calculator = new Calculator.Calculator { transportMode = Calculator.TransportModes.train, distance = 40, numDays = 7 };
            double expected = 3 * 40 * (7 * 2); // Assuming the weighting for train is 3
            Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
        }

        [Test]
        public void SustainabilityWeighting_BusMode_CalculatesCorrectly()
        {
            var calculator = new Calculator.Calculator { transportMode = Calculator.TransportModes.bus, distance = 45, numDays = 5 };
            double expected = 3 * 45 * (5 * 2); // Assuming the weighting for bus is 3
            Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
        }

        [Test]
        public void SustainAbilityWeighting_TramMode_CalculatesCorrectly()
        {
            var calculator = new Calculator.Calculator { transportMode = Calculator.TransportModes.tram, distance = 45, numDays = 5 };
            double expected = 3 * 45 * (5 * 2); // Assuming the weighting for bus is 3
            Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
        }

        [Test]
        public void TransportModes_EnumValues_AreCorrect()
        {
            var petrolValue = (int)Calculator.TransportModes.petrol;
            Assert.That(petrolValue, Is.EqualTo(0));
        }

        [Test]
        public void TransportModes_EnumNames_AreCorrect()
        {
            var petrolName = Enum.GetName(typeof(Calculator.TransportModes), 0);
            Assert.That(petrolName, Is.EqualTo("petrol"));
        }

        [Test]
        public void TransportModes_DisplayNames_AreCorrect()
        {
            var petrolDisplayName = Enum.GetName(typeof(Calculator.TransportModes), Calculator.TransportModes.petrol);
            Assert.That(petrolDisplayName, Is.EqualTo("petrol"));
        }

        [Test]
        public void ConvertDistance_MinimumMiles_NoConversionNeeded()
        {
            var calculator = new Calculator.Calculator { distance = Calculator.Calculator.distanceMin, milesOrKms = Calculator.DistanceMeasurement.miles };
            Assert.That(calculator.convertDistance(), Is.EqualTo(Calculator.Calculator.distanceMin));
        }

        [Test]
        public void ConvertDistance_MinimumKilometers_ConvertsCorrectly()
        {
            var calculator = new Calculator.Calculator { distance = Calculator.Calculator.distanceMin, milesOrKms = Calculator.DistanceMeasurement.kms };
            double expectedMiles = Calculator.Calculator.distanceMin / 1.609344;
            Assert.That(calculator.convertDistance(), Is.EqualTo(expectedMiles).Within(0.00001));
        }

        [Test]
        public void ConvertDistance_MaximumMiles_NoConversionNeeded()
        {
            var calculator = new Calculator.Calculator { distance = Calculator.Calculator.distanceMax, milesOrKms = Calculator.DistanceMeasurement.miles };
            Assert.That(calculator.convertDistance(), Is.EqualTo(Calculator.Calculator.distanceMax));
        }
    }
}