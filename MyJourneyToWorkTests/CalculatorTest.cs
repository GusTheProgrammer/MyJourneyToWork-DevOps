using Calculator;

namespace MyJourneyToWorkTests;
public class CalculatorTests
{
    private Calculator.Calculator calculator;

    [SetUp]
    public void Setup()
    {
        calculator = new Calculator.Calculator();
    }

    [Test]
    public void ConvertDistance_KilometersToMiles_ConvertsCorrectly()
    {
        calculator.distance = 10;
        calculator.milesOrKms = DistanceMeasurement.kms;
        Assert.That(calculator.convertDistance(), Is.EqualTo(6.21371).Within(0.00001));
    }

    [Test]
    public void ConvertDistance_MilesToMiles_NoConversion()
    {
        calculator.distance = 10;
        calculator.milesOrKms = DistanceMeasurement.miles;
        Assert.That(calculator.convertDistance(), Is.EqualTo(10)); Assert.That(calculator.convertDistance(), Is.EqualTo(10));
    }

    [Test]
    public void SustainabilityWeighting_PetrolMode_CalculatesCorrectly()
    {
        calculator.transportMode = TransportModes.petrol;
        calculator.distance = 10;
        calculator.numDays = 5;
        double expected = 8 * 10 * (5 * 2);
        Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
    }

    [Test]
    public void SustainabilityWeighting_DieselMode_CalculatesCorrectly()
    {
        calculator.transportMode = TransportModes.deisel; 
        calculator.distance = 15; 
        calculator.numDays = 3;
        double expected = 10 * 15 * (3 * 2);
        Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
    }

    [Test]
    public void SustainabilityWeighting_HybridMode_CalculatesCorrectly()
    {
        calculator.transportMode = TransportModes.hybrid;
        calculator.distance = 20;
        calculator.numDays = 4;
        double expected = 6 * 20 * (4 * 2);
        Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
    }

    [Test]
    public void SustainabilityWeighting_ElectricMode_CalculatesCorrectly()
    {
        calculator.transportMode = TransportModes.electric;
        calculator.distance = 25;
        calculator.numDays = 2;
        double expected = 4 * 25 * (2 * 2);
        Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
    }

    [Test]
    public void SustainabilityWeighting_MotorbikeMode_CalculatesCorrectly()
    {
        calculator.transportMode = TransportModes.motorbike;
        calculator.distance = 30;
        calculator.numDays = 1;
        double expected = 3 * 30 * (1 * 2);
        Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
    }

    [Test]
    public void SustainabilityWeighting_ElectricBikeMode_CalculatesCorrectly()
    {
        calculator.transportMode = TransportModes.electricbike;
        calculator.distance = 35;
        calculator.numDays = 6;
        double expected = 2 * 35 * (6 * 2); 
        Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
    }

    [Test]
    public void SustainabilityWeighting_TrainMode_CalculatesCorrectly()
    {
        calculator.transportMode = TransportModes.train;
        calculator.distance = 40;
        calculator.numDays = 7;
        double expected = 3 * 40 * (7 * 2);
        Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
    }

    [Test]
    public void SustainabilityWeighting_BusMode_CalculatesCorrectly()
    {
        calculator.transportMode = TransportModes.bus;
        calculator.distance = 45;
        calculator.numDays = 5;
        double expected = 3 * 45 * (5 * 2);
        Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
    }

    [Test]
    public void SustainAbilityWeighting_TramMode_CalculatesCorrectly()
    {
        calculator.transportMode = TransportModes.tram;
        calculator.distance = 45;
        calculator.numDays = 5;
        double expected = 3 * 45 * (5 * 2);
        Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
    }

    [Test]
    public void SustainAbilityWeighting_CyclingMode_CalculatesCorrectly()
    {
        calculator.transportMode = TransportModes.cycling;
        calculator.distance = 30;
        calculator.numDays = 3;
        double expected = 0.005 * 30 * (3 * 2);
        Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
    }


    [Test]
    public void SustainAbilityWeighting_WalkingMode_CalculatesCorrectly()
    {
        calculator.transportMode = TransportModes.walking;
        calculator.distance = 10;
        calculator.numDays = 4;
        double expected = 0.005 * 10 * (4 * 2);
        Assert.That(calculator.sustainabilityWeighting, Is.EqualTo(expected));
    }

    [Test]
    public void TransportModes_EnumValues_AreCorrect()
    {
        var petrolValue = (int)TransportModes.petrol;
        Assert.That(petrolValue, Is.EqualTo(0));
    }

    [Test]
    public void TransportModes_EnumNames_AreCorrect()
    {
        var petrolName = Enum.GetName(typeof(TransportModes), 0);
        Assert.That(petrolName, Is.EqualTo("petrol"));
    }

    [Test]
    public void TransportModes_DisplayNames_AreCorrect()
    {
        var petrolDisplayName = Enum.GetName(typeof(TransportModes), TransportModes.petrol);
        Assert.That(petrolDisplayName, Is.EqualTo("petrol"));
    }

    [Test]
    public void ConvertDistance_MinimumMiles_NoConversionNeeded()
    {
        calculator.distance = Calculator.Calculator.distanceMin;
        calculator.milesOrKms = Calculator.DistanceMeasurement.miles;
        Assert.That(calculator.convertDistance(), Is.EqualTo(Calculator.Calculator.distanceMin));
    }

    [Test]
    public void ConvertDistance_MinimumKilometers_ConvertsCorrectly()
    {
        calculator.distance = Calculator.Calculator.distanceMin;
        calculator.milesOrKms = Calculator.DistanceMeasurement.kms;
        double expectedMiles = Calculator.Calculator.distanceMin / 1.609344;
        Assert.That(calculator.convertDistance(), Is.EqualTo(expectedMiles).Within(0.00001));
    }

    [Test]
    public void ConvertDistance_MaximumMiles_NoConversionNeeded()
    {
        calculator.distance = Calculator.Calculator.distanceMax;
        calculator.milesOrKms = Calculator.DistanceMeasurement.miles;
        Assert.That(calculator.convertDistance(), Is.EqualTo(Calculator.Calculator.distanceMax));
    }

    [Test]
    public void TransportationCost_PetrolMode_CalculatesCorrectly()
    {
        calculator.transportMode = TransportModes.petrol;
        calculator.distance = 20;
        calculator.milesOrKms = DistanceMeasurement.miles;
        calculator.numDays = 5;
        double expectedCost = 0.16 * 20 * 5;
        Assert.That(calculator.TransportationCost, Is.EqualTo(expectedCost));
    }

    [Test]
    public void TransportationCost_BusMode_FixedFareAppliedEvery15Miles()
    {
        calculator.transportMode = TransportModes.bus;
        calculator.distance = 25; // More than 15 miles
        calculator.milesOrKms = DistanceMeasurement.miles;
        // Fixed fare is 1.35 every 15 miles
        double expectedCost = 1.35 * 2;
        Assert.That(calculator.TransportationCost, Is.EqualTo(expectedCost));
    }


}