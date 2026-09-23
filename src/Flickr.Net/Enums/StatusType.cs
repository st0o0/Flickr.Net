using System.Runtime.Serialization;

namespace Flickr.Net.Enums;
/// <summary>Status of an asynchronous upload ticket.</summary>
public enum StatusType
{    [EnumMember(Value = "0")]
    NotCompleted = 0,
    [EnumMember(Value = "1")]
    Completed = 1,
    [EnumMember(Value = "2")]
    Failed = 2,
}
