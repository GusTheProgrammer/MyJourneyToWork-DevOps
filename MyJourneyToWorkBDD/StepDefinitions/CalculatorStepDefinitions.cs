using Calculator;
using NUnit.Framework;
namespace MyJourneyToWorkBDD.StepDefinitions;

[Binding]
public class SustainabilityWeightingSteps
{
    private Calculator.Calculator? calculator;
    private double result;
    private double transportationCost;


    [Given(@"I have chosen '(.*)' as my transport mode")]
    public void GivenIHaveChosenAsMyTransportMode(string mode)
    {
        calculator = new Calculator.Calculator
        {
            transportMode = (TransportModes)Enum.Parse(typeof(TransportModes), mode)
        };
    }

    [Given(@"I set the distance to '(.*)' miles")]
    public void GivenISetTheDistanceToMiles(int distance)
    {
        if (calculator == null)
            throw new InvalidOperationException("Calculator is not initialized.");

        calculator.distance = distance;
        calculator.milesOrKms = DistanceMeasurement.miles;
    }

    [Given(@"I travel '(.*)' days a week")]
    public void GivenITravelDaysAWeek(int days)
    {
        if (calculator == null)
            throw new InvalidOperationException("Calculator is not initialized.");

        calculator.numDays = days;
    }

    [When(@"I calculate the sustainability weighting")]
    public void WhenICalculateTheSustainabilityWeighting()
    {
        if (calculator == null)
            throw new InvalidOperationException("Calculator is not initialized.");

        result = calculator.sustainabilityWeighting;
    }

    [Then(@"the result should be '(.*)'")]
    public void ThenTheResultShouldBe(int expected)
    {
        Assert.AreEqual(expected, result);
    }

    [When(@"I calculate the transportation cost")]
    public void WhenICalculateTheTransportationCost()
    {
        if (calculator == null)
            throw new InvalidOperationException("Calculator is not initialized.");

        transportationCost = calculator.TransportationCost;
    }

    [Then(@"the transportation cost should be '(.*)'")]
    public void ThenTheTransportationCostShouldBe(double expectedCost)
    {
        Assert.AreEqual(expectedCost, transportationCost, 0.01);
    }
}
