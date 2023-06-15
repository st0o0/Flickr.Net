namespace Flickr.Net.Core.Internals.Attributes;

/// <summary>
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
internal class FlickrJsonPropertyNameAttribute : Attribute
{
    /// <summary>
    /// </summary>
    public FlickrJsonPropertyNameAttribute(string JSONPropertyName)
    {
        Name = JSONPropertyName;
    }

    /// <summary>
    /// </summary>
    public string Name { get; }
}