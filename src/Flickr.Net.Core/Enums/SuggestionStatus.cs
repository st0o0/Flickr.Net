namespace Flickr.Net.Core.Enums;

/// <summary>
/// The status of a location suggestion.
/// </summary>
/// <remarks></remarks>
[JsonConverter(typeof(StringEnumConverter))]
public enum SuggestionStatus
{
    /// <summary>
    /// The suggestion is in a pending state.
    /// </summary>
    [EnumMember(Value = "0")]
    Pending = 0,

    /// <summary>
    /// The suggestion has been approved.
    /// </summary>
    [EnumMember(Value = "1")]
    Approved = 1,

    /// <summary>
    /// The suggestion has been rejected.
    /// </summary>
    [EnumMember(Value = "2")]
    Rejected = 2
}