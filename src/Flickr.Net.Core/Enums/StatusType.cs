namespace Flickr.Net.Core.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum StatusType
{
    [EnumMember(Value = "0")]
    NotCompleted = 0,

    [EnumMember(Value = "1")]
    Completed = 1,

    [EnumMember(Value = "2")]
    Failed = 2,
}
