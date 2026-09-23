namespace Flickr.Net.Internals.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
internal class FlickrJsonPropertyNameAttribute(string jsonPropertyName) : Attribute
{
    /// <summary>The display name.</summary>
    public string Name { get; } = jsonPropertyName;
}
