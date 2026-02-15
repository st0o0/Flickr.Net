namespace Flickr.Net.Internals.Attributes;

/// <summary>
/// </summary>
/// <remarks>
/// </remarks>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
internal class FlickrJsonPropertyNameAttribute(string jsonPropertyName) : Attribute
{

    /// <summary>
    /// </summary>
    public string Name { get; } = jsonPropertyName;
}