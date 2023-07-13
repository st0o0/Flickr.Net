namespace Flickr.Net.Core.Enums;

public enum SizeType
{
    [EnumMember(Value = "_t")]
    Thumbnail,

    [EnumMember(Value = "_s")]
    Square,

    [EnumMember(Value = "_q")]
    LargeSquare,

    [EnumMember(Value = "_m")]
    Small,

    [EnumMember(Value = "_n")]
    Small320,

    [EnumMember(Value = "_w")]
    Small400,

    [EnumMember(Value = "")]
    Medium,

    [EnumMember(Value = "_z")]
    Medium640,

    [EnumMember(Value = "_c")]
    Medium800,

    [EnumMember(Value = "_b")]
    Large,

    [EnumMember(Value = "_h")]
    Large1600,

    [EnumMember(Value = "_k")]
    Large2048,

    [EnumMember(Value = "_o")]
    Original
}
