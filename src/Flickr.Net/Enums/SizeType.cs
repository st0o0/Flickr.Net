namespace Flickr.Net.Enums;

/// <summary>
/// </summary>
public enum SizeType
{
    /// <summary>
    /// </summary>
    [EnumMember(Value = "_t")]
    Thumbnail,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "_s")]
    Square,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "_q")]
    LargeSquare,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "_m")]
    Small,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "_n")]
    Small320,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "_w")]
    Small400,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "")]
    Medium,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "_z")]
    Medium640,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "_c")]
    Medium800,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "_b")]
    Large,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "_h")]
    Large1600,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "_k")]
    Large2048,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "_o")]
    Original
}
