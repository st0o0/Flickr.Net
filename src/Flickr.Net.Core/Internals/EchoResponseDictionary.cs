namespace Flickr.Net.Core.Internals;

/// <summary>
/// The response returned by the <see cref="IFlickrTest.EchoAsync(Dictionary{string, string},
/// CancellationToken)"/> method.
/// </summary>
public sealed class EchoResponseDictionary : Dictionary<string, string>
{
}