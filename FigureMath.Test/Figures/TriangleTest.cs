using FigureMath.Figures;

namespace FigureMath.Test.Figures;

[TestClass]
public class TriangleTest
{
    private readonly (double A, double B, double C) _correctSideLengths = (10d, 8d, 5d);
    private readonly (double A, double B, double C) _incorrectSideLengths = (1d, 2d, 3d);

    [TestMethod]
    public void InitializeTriangleTest_CorrectProps_ShouldCreateTriangle()
    {
        var (expectedA, expectedB, expectedC) = _correctSideLengths;

        var triangle = new Triangle(expectedA, expectedB, expectedC);

        Assert.AreEqual(expectedA, triangle.A);
        Assert.AreEqual(expectedB, triangle.B);
        Assert.AreEqual(expectedC, triangle.C);
    }

    [TestMethod]
    public void InitializeTriangleTest_IncorrectProps_ShouldThrowException()
    {
        Assert.ThrowsException<ArgumentException>(() => new Triangle(_incorrectSideLengths.A, _incorrectSideLengths.B, _incorrectSideLengths.C));
    }

    [TestMethod]
    public void TryCreateTriangleTest_CorrectProps_ShouldCreateTriangle()
    {
        var (expectedA, expectedB, expectedC) = _correctSideLengths;

        var actualCreateResult = Triangle.TryCreate(expectedA, expectedB, expectedC, out var actualTriangle);

        Assert.IsTrue(actualCreateResult);
        Assert.IsNotNull(actualTriangle);
        Assert.AreEqual(expectedA, actualTriangle.A);
        Assert.AreEqual(expectedB, actualTriangle.B);
        Assert.AreEqual(expectedC, actualTriangle.C);
    }

    [TestMethod]
    public void TryCreateTriangleTest_IncorrectProps_ShouldReturnFalse()
    {
        var actualCreateResult = Triangle.TryCreate(_incorrectSideLengths.A, _incorrectSideLengths.B, _incorrectSideLengths.C, out var actualTriangle);

        Assert.IsFalse(actualCreateResult);
        Assert.IsNull(actualTriangle);
    }

    [TestMethod]
    public void CalcArea_ShouldCalcArea()
    {
        var triangle = new Triangle(_correctSideLengths.A, _correctSideLengths.B, _correctSideLengths.C);
        var expectedArea = 19.81003533565753;

        var actualArea = triangle.CalcArea();

        Assert.AreEqual(expectedArea, actualArea);
    }

    [TestMethod]
    public void IsRightAngle_ShouldReturnTrue()
    {
        var triangle = new Triangle(3, 4, 5);

        var actual = triangle.IsRightAngle;

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void IsRightAngle_ShouldReturnFalse()
    {
        var triangle = new Triangle(3, 3, 5);

        var actual = triangle.IsRightAngle;

        Assert.IsFalse(actual);
    }
}