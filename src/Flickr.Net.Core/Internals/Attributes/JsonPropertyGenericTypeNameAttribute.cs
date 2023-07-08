namespace Flickr.Net.Core.Internals.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class JsonPropertyGenericTypeNameAttribute : Attribute
{
    public int TypeParameterPosition { get; }

    public JsonPropertyGenericTypeNameAttribute(int position)
    {
        TypeParameterPosition = position;
    }
}