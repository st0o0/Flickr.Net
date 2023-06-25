using System.Reflection;
using System.Runtime.Serialization;

namespace Flickr.Net.Core.Internals;

internal static class EnumExtensions{
    public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        return type.GetField(name).GetCustomAttribute<TAttribute>();  
    }

    public static string GetEnumMemberValue(this Enum value)
    {
        var attr = value.GetAttribute<EnumMemberAttribute>();
        if(attr.IsValueSetExplicitly)
        {
            return attr.Value;
        }
        return string.Empty;
    }
}