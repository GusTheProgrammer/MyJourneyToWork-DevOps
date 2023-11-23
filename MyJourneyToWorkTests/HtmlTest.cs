using Moq;
using Microsoft.Extensions.Logging;
using MyJourneyToWork.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyJourneyToWorkTests;


[TestFixture]
public class IndexModelTests
{
    private Mock<ILogger<IndexModel>> _loggerMock;
    private IndexModel _indexModel;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<IndexModel>>();
        _indexModel = new IndexModel(_loggerMock.Object);
    }

    [Test]
    public void Constructor_InitializesLogger()
    {
        // Assert
        Assert.IsNotNull(_indexModel);
    }

    [Test]
    public void OnGet_ExecutesSuccessfully()
    {
        // Act
        Assert.DoesNotThrow(() => _indexModel.OnGet());
    }




}


[TestFixture]
public class ErrorModelTests
{
    private Mock<ILogger<ErrorModel>> _loggerMock;
    private ErrorModel _errorModel;
    private DefaultHttpContext _httpContext;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<ErrorModel>>();
        _errorModel = new ErrorModel(_loggerMock.Object);
        _httpContext = new DefaultHttpContext();
        _errorModel.PageContext = new PageContext
        {
            HttpContext = _httpContext
        };
    }

    [Test]
    public void Constructor_InitializesLogger()
    {
        // Assert
        Assert.IsNotNull(_errorModel);
    }

    [Test]
    public void ShowRequestId_ReturnsTrue_WhenRequestIdIsSet()
    {
        // Arrange
        _errorModel.RequestId = "test-request-id";

        // Act & Assert
        Assert.IsTrue(_errorModel.ShowRequestId);
    }

    [Test]
    public void ShowRequestId_ReturnsFalse_WhenRequestIdIsNotSet()
    {
        // Arrange
        _errorModel.RequestId = null;

        // Act & Assert
        Assert.IsFalse(_errorModel.ShowRequestId);
    }


}


[TestFixture]
public class CalculatorModelTests
{
    private CalculatorModel _calculatorModel;

    [SetUp]
    public void Setup()
    {
        _calculatorModel = new CalculatorModel();
    }

    [Test]
    public void OnGet_ExecutesSuccessfully()
    {
        // Act & Assert
        Assert.DoesNotThrow(() => _calculatorModel.OnGet());
    }

    [Test]
    public void CalculatorProperty_CanBeSet()
    {
        // Arrange
        var calculator = new Calculator.Calculator();

        // Act
        _calculatorModel.calculator = calculator;

        // Assert
        Assert.That(_calculatorModel.calculator, Is.EqualTo(calculator));
    }


}


[TestFixture]
public class PrivacyModelTests
{
    private Mock<ILogger<PrivacyModel>> _loggerMock;
    private PrivacyModel _privacyModel;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<PrivacyModel>>();
        _privacyModel = new PrivacyModel(_loggerMock.Object);
    }

    [Test]
    public void Constructor_InitializesLogger()
    {
        // Assert
        Assert.IsNotNull(_privacyModel);
    }

    [Test]
    public void OnGet_ExecutesSuccessfully()
    {
        // Act & Assert
        Assert.DoesNotThrow(() => _privacyModel.OnGet());
    }

}