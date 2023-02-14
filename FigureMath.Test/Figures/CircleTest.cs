using FigureMath.Figures;

namespace FigureMath.Test.Figures;

[TestClass]
public class CircleTest
{
    [TestMethod]
    public void InitializeCircleTest_CorrectProps_ShouldCreateCircle()
    {
        var expectedRadius = 10d;

        var circle = new Circle(expectedRadius);

        Assert.AreEqual(expectedRadius, circle.Radius);
    }

    [TestMethod]
    public void InitializeCircleTest_IncorrectRadius_ShouldThrowException()
    {
        Assert.ThrowsException<ArgumentException>(() => new Circle(0));
        Assert.ThrowsException<ArgumentException>(() => new Circle(-10));
    }

    [TestMethod]
    public void TryCreateCircleTest_CorrectRadius_ShouldCreateCircle()
    {
        var expectedRadius = 10d;
        var expectedCreateResult = true;

        var actualCreateResult = Circle.TryCreate(expectedRadius, out var circle);

        Assert.AreEqual(expectedCreateResult, actualCreateResult);
        Assert.IsNotNull(circle);
        Assert.AreEqual(expectedRadius, circle.Radius);
    }

    [TestMethod]
    public void TryCreateCircleTest_IncorrectRadius_ShouldReturnFalse()
    {
        var expectedCreateResult = false;

        var actualCreateResult = Circle.TryCreate(-10, out var circle);

        Assert.AreEqual(expectedCreateResult, actualCreateResult);
        Assert.IsNull(circle);
    }

    [TestMethod]
    public void CalcAreaTest_CorrectProps_ShouldCalcArea()
    {
        var expectedArea = 314.1592653589793;
        var circle = new Circle(10);

        var actualArea = circle.CalcArea();

        Assert.AreEqual(expectedArea, actualArea);
    }
}