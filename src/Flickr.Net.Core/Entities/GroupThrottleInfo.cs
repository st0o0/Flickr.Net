namespace Flickr.Net.Core.Entities;

/// <summary>
/// Throttle information about a group (i.e. posting limit)
/// </summary>
public sealed class GroupThrottleInfo : IFlickrParsable
{
    /// <summary>
    /// The number of posts in each period allowed to this group.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// The posting limit mode for a group.
    /// </summary>
    public GroupThrottleMode Mode { get; set; }

    private static GroupThrottleMode ParseMode(string mode)
    {
        return mode switch
        {
            "day" => GroupThrottleMode.PerDay,
            "week" => GroupThrottleMode.PerWeek,
            "month" => GroupThrottleMode.PerMonth,
            "ever" => GroupThrottleMode.Ever,
            "none" => GroupThrottleMode.NoLimit,
            "disabled" => GroupThrottleMode.Disabled,
            _ => throw new ArgumentException(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Unknown mode found {0}", mode), nameof(mode)),
        };
    }

    /// <summary>
    /// The number of remainging posts allowed by this user. If unauthenticated then this will be zero.
    /// </summary>
    public int Remaining { get; set; }

    void IFlickrParsable.Load(XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "count":
                    Count = reader.ReadContentAsInt();
                    break;

                case "mode":
                    Mode = ParseMode(reader.Value);
                    break;

                case "remaining":
                    Remaining = reader.ReadContentAsInt();
                    break;
            }
        }
        reader.Read();
    }
}