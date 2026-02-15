using System.Globalization;
using Flickr.Net.Enums;

namespace Flickr.Net.Internals;

/// <summary>
/// Summary description for BoundaryBox.
/// </summary>
public class BoundaryBox
{
    private double minimumLat = -90;
    private double minimumLon = -180;
    private double maximumLat = 90;
    private double maximumLon = 180;

    /// <summary>
    /// Default constructor, specifying only the accuracy level.
    /// </summary>
    /// <param name="accuracy">The <see cref="GeoAccuracy"/> of the search parameter.</param>
    public BoundaryBox(GeoAccuracy accuracy)
    {
        Accuracy = accuracy;
    }

    /// <summary>
    /// Constructor for the <see cref="BoundaryBox"/>
    /// </summary>
    /// <param name="points">A comma seperated list of co-ordinates defining the boundary box.</param>
    /// <param name="accuracy">The <see cref="GeoAccuracy"/> of the search parameter.</param>
    public BoundaryBox(string points, GeoAccuracy accuracy) : this(points)
    {
        Accuracy = accuracy;
    }

    /// <summary>
    /// Constructor for the <see cref="BoundaryBox"/>
    /// </summary>
    /// <param name="points">A comma seperated list of co-ordinates defining the boundary box.</param>
    public BoundaryBox(string points)
    {
        var splits = points.Split(',');

        if (splits.Length != 4)
        {
            throw new ArgumentException("Parameter must contain 4 values, seperated by commas.", nameof(points));
        }

        try
        {
            MinimumLongitude = double.Parse(splits[0], NumberFormatInfo.InvariantInfo);
            MinimumLatitude = double.Parse(splits[1], NumberFormatInfo.InvariantInfo);
            MaximumLongitude = double.Parse(splits[2], NumberFormatInfo.InvariantInfo);
            MaximumLatitude = double.Parse(splits[3], NumberFormatInfo.InvariantInfo);
        }
        catch (FormatException)
        {
            throw new ArgumentException("Unable to parse points as integer values", nameof(points));
        }
    }

    /// <summary>
    /// Constructor for the <see cref="BoundaryBox"/>.
    /// </summary>
    /// <param name="minimumLongitude">
    /// The minimum longitude of the boundary box. Range of -180 to 180 allowed.
    /// </param>
    /// <param name="minimumLatitude">
    /// The minimum latitude of the boundary box. Range of -90 to 90 allowed.
    /// </param>
    /// <param name="maximumLongitude">
    /// The maximum longitude of the boundary box. Range of -180 to 180 allowed.
    /// </param>
    /// <param name="maximumLatitude">
    /// The maximum latitude of the boundary box. Range of -90 to 90 allowed.
    /// </param>
    /// <param name="accuracy">The <see cref="GeoAccuracy"/> of the search parameter.</param>
    public BoundaryBox(double minimumLongitude, double minimumLatitude, double maximumLongitude, double maximumLatitude, GeoAccuracy accuracy)
        : this(minimumLongitude, minimumLatitude, maximumLongitude, maximumLatitude)
    {
        Accuracy = accuracy;
    }

    /// <summary>
    /// Constructor for the <see cref="BoundaryBox"/>.
    /// </summary>
    /// <param name="minimumLongitude">
    /// The minimum longitude of the boundary box. Range of -180 to 180 allowed.
    /// </param>
    /// <param name="minimumLatitude">
    /// The minimum latitude of the boundary box. Range of -90 to 90 allowed.
    /// </param>
    /// <param name="maximumLongitude">
    /// The maximum longitude of the boundary box. Range of -180 to 180 allowed.
    /// </param>
    /// <param name="maximumLatitude">
    /// The maximum latitude of the boundary box. Range of -90 to 90 allowed.
    /// </param>
    public BoundaryBox(double minimumLongitude, double minimumLatitude, double maximumLongitude, double maximumLatitude)
    {
        MinimumLatitude = minimumLatitude;
        MinimumLongitude = minimumLongitude;
        MaximumLatitude = maximumLatitude;
        MaximumLongitude = maximumLongitude;
    }

    /// <summary>
    /// Example boundary box for the UK.
    /// </summary>
    public static BoundaryBox UK => new(-11.118164, 49.809632, 1.625977, 62.613562);

    /// <summary>
    /// Example boundary box for Newcastle upon Tyne, England.
    /// </summary>
    public static BoundaryBox UKNewcastle => new(-1.71936, 54.935821, -1.389771, 55.145919);

    /// <summary>
    /// Example boundary box for the USA (excludes Hawaii and Alaska).
    /// </summary>
    public static BoundaryBox Usa => new(-130.429687, 22.43134, -58.535156, 49.382373);

    /// <summary>
    /// Example boundary box for Canada.
    /// </summary>
    public static BoundaryBox Canada => new(-143.085937, 41.640078, -58.535156, 73.578167);

    /// <summary>
    /// Example boundary box for the whole world.
    /// </summary>
    public static BoundaryBox World => new(-180, -90, 180, 90);

    /// <summary>
    /// The search accuracy - optional. Defaults to <see cref="GeoAccuracy.Street"/>.
    /// </summary>
    public GeoAccuracy Accuracy { get; init; } = GeoAccuracy.Street;

    /// <summary>
    /// The minimum latitude of the boundary box, i.e. bottom left hand corner.
    /// </summary>
    public double MinimumLatitude
    {
        get => minimumLat;
        init
        {
            if (value is < -90 or > 90)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Must be between -90 and 90");
            }
            IsSet = true;
            minimumLat = value;
        }
    }

    /// <summary>
    /// The minimum longitude of the boundary box, i.e. bottom left hand corner. Range of -180 to
    /// 180 allowed.
    /// </summary>
    public double MinimumLongitude
    {
        get => minimumLon;
        init
        {
            if (value is < -180 or > 180)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Must be between -180 and 180");
            }
            IsSet = true;
            minimumLon = value;
        }
    }

    /// <summary>
    /// The maximum latitude of the boundary box, i.e. top right hand corner. Range of -90 to 90 allowed.
    /// </summary>
    public double MaximumLatitude
    {
        get => maximumLat;
        init
        {
            if (value is < -90 or > 90)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Must be between -90 and 90");
            }
            IsSet = true;
            maximumLat = value;
        }
    }

    /// <summary>
    /// The maximum longitude of the boundary box, i.e. top right hand corner. Range of -180 to 180 allowed.
    /// </summary>
    public double MaximumLongitude
    {
        get => maximumLon;
        init
        {
            if (value is < -180 or > 180)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Must be between -180 and 180");
            }
            IsSet = true;
            maximumLon = value;
        }
    }

    /// <summary>
    /// Gets weither the boundary box has been set or not.
    /// </summary>
    internal bool IsSet { get; private set; }

    /// <summary>
    /// Overrides the ToString method.
    /// </summary>
    /// <returns>A comma seperated list of co-ordinates defining the boundary box.</returns>
    public override string ToString()
    {
        return string.Format(NumberFormatInfo.InvariantInfo, "{0},{1},{2},{3}", MinimumLongitude, MinimumLatitude, MaximumLongitude, MaximumLatitude);
    }

    /// <summary>
    /// Calculates the distance in miles from the SW to the NE corners of this boundary box.
    /// </summary>
    /// <returns></returns>
    public double DiagonalDistanceInMiles()
    {
        return DiagonalDistance() * 3963.191;
    }

    /// <summary>
    /// Calculates the distance in kilometres from the SW to the NE corners of this boundary box.
    /// </summary>
    /// <returns></returns>
    public double DiagonalDistanceInKM()
    {
        return DiagonalDistance() * 6378.137;
    }

    private double DiagonalDistance()
    {
        var latRad1 = MinimumLatitude / 180.0 * Math.PI;
        var latRad2 = MaximumLatitude / 180.0 * Math.PI;
        var lonRad1 = MinimumLongitude / 180.0 * Math.PI;
        var lonRad2 = MaximumLongitude / 180.0 * Math.PI;

        var e = Math.Acos(Math.Sin(latRad1) * Math.Sin(latRad2) + Math.Cos(latRad1) * Math.Cos(latRad2) * Math.Cos(lonRad2 - lonRad1));
        return e;
    }
}