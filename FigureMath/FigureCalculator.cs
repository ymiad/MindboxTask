using FigureMath.Interfaces;

namespace FigureMath;

public static class FigureCalculator
{
    public static double CalculateArea(IAreaCalculable areaCalculable)
    {
        return areaCalculable.CalcArea();
    }
}