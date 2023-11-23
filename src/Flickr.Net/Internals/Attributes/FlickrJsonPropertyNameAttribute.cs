namespace Flickr.Net.Internals.Attributes;

/// <summary>
/// </summary>
/// <remarks>
/// </remarks>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
internal class FlickrJsonPropertyNameAttribute(string JSONPropertyName) : Attribute
{

    /// <summary>
    /// </summary>
    public string Name { get; } = JSONPropertyName;
}