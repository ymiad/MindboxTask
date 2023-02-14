using FigureMath.Interfaces;

namespace FigureMath.Figures;

/// <summary>Provides an object representation of triangle.</summary>
public class Triangle : IAreaCalculable
{
    private const string IncorrectSizeMessage = "The sum of two sides must be larger than the third.";

    /// <summary>Specifies the length of A side.</summary>
    public double A { get; }

    /// <summary>Specifies the length of B side.</summary>
    public double B { get; }

    /// <summary>Specifies the length of C side.</summary>
    public double C { get; }

    /// <summary>Specifies if the <see cref="Triangle"/> is right angle.</summary>
    /// <returns><see langword="true" /> if the <see cref="Triangle" /> is right angle; otherwise, <see langword="false" />.</returns>
    public bool IsRightAngle { get; }

    /// <summary>Initializes a new instance of the <see cref="Triangle"/> class.</summary>
    /// <param name="a">A side length.</param>
    /// <param name="b">B side length.</param>
    /// <param name="c">C side length.</param>
    /// <exception cref="ArgumentException">Throws <see cref="ArgumentException"/> if the sum of two sides less than the third.</exception>
    public Triangle(double a, double b, double c)
    {
        if (!IsTriangleValid(a, b, c))
        {
            throw new ArgumentException(IncorrectSizeMessage);
        }

        A = a;
        B = b;
        C = c;

        IsRightAngle = IsTriangleRightAngle();
    }

    /// <summary>Creates a new <see cref="Triangle"/> using the specified a, b and c parameters.</summary>
    /// <param name="a">A side length.</param>
    /// <param name="b">B side length.</param>
    /// <param name="c">C side length.</param>
    /// <param name="triangle">When this method returns, contains a <see cref="Triangle" /> constructed from <paramref name="a" /> and <paramref name="b" /> and <paramref name="c" /> . This parameter is passed uninitialized.</param>
    /// <returns><see langword="true" /> if the <see cref="Triangle" /> was successfully created; otherwise, <see langword="false" />.</returns>
    public static bool TryCreate(double a, double b, double c, out Triangle? triangle)
    {
        var isTriangleValid = IsTriangleValid(a, b, c);
        triangle = isTriangleValid ? new Triangle(a, b, c) : null;
        return isTriangleValid;
    }

    /// <summary>Calculates the area of <see cref="Triangle"/>.</summary>
    /// <returns>Calculated area of <see cref="Triangle"/></returns>
    public virtual double CalcArea()
    {
        var p = (A + B + C) / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

    private static bool IsTriangleValid(double a, double b, double c)
    {
        return a < b + c && b < a + c && c < b + a;
    }

    private bool IsTriangleRightAngle()
    {
        var powA = Math.Pow(A, 2);
        var powB = Math.Pow(B, 2);
        var powC = Math.Pow(C, 2);

        return powA == powB + powC || powB == powA + powC || powC == powA + powB;
    }
}