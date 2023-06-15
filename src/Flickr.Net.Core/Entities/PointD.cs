namespace Flickr.Net.Core.Entities;

/// <summary>
/// A point structure for holding double-floating points precision data.
/// </summary>
public struct PointD
{
    private double x;
    private double y;

    /// <summary>
    /// The X position of the point.
    /// </summary>
    public double X { get { return x; } }

    /// <summary>
    /// The Y position of the point.
    /// </summary>
    public double Y { get { return y; } }

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public PointD(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// For predefined value types, the equality operator (==) returns true if the values of its
    /// operands are equal, false otherwise.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <returns></returns>
    public static bool operator ==(PointD point1, PointD point2)
    {
        return Math.Abs(point1.X - point2.X) < 0.001 && Math.Abs(point1.Y - point2.Y) < 0.001;
    }

    /// <summary>
    /// For predefined value types, the equality operator (!=) returns false if the values of its
    /// operands are equal, true otherwise.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <returns></returns>
    public static bool operator !=(PointD point1, PointD point2)
    {
        return Math.Abs(point1.X - point2.X) > 0.001 || Math.Abs(point1.Y - point2.Y) > 0.001;
    }

    /// <summary>
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj is PointD)
        {
            PointD p = (PointD)obj;
            return this == p;
        }
        return false;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return X.GetHashCode() + Y.GetHashCode();
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return base.ToString();
    }
}