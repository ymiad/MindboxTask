using FigureMath.Interfaces;

namespace FigureMath.Figures;

/// <summary>Provides an object representation of circle.</summary>
public class Circle : IAreaCalculable
{
    private const string IncorrectRadiusMessage = "Radius should be greater than 0.";

    /// <summary>Specifies the radius.</summary>
    public double Radius { get; }

    /// <summary>Initializes a new instance of the <see cref="Circle"/> class.</summary>
    /// <param name="radius">Radius.</param>
    /// <exception cref="ArgumentException">Throws <see cref="ArgumentException"/> if the less or equals to 0.</exception>
    public Circle(double radius)
    {
        if (!IsCircleValid(radius))
        {
            throw new ArgumentException(IncorrectRadiusMessage);
        }

        Radius = radius;
    }

    /// <summary>Creates a new <see cref="Circle"/> using the specified radius.</summary>
    /// <param name="radius">Radius.</param>
    /// <param name="circle">When this method returns, contains a <see cref="Circle"/> constructed from <paramref name="radius"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true" /> if the <see cref="Circle"/> was successfully created; otherwise, <see langword="false" />.</returns>
    public static bool TryCreate(double radius, out Circle? circle)
    {
        var isCircleValid = IsCircleValid(radius);
        circle = isCircleValid ? new Circle(radius) : null;
        return isCircleValid;
    }

    private static bool IsCircleValid(double radius)
    {
        return radius > 0;
    }

    /// <summary>Calculates the area of <see cref="Circle"/>.</summary>
    /// <returns>Calculated area of <see cref="Circle"/>.</returns>
    public double CalcArea()
    {
        return Math.Pow(Radius, 2) * Math.PI;
    }
}