using Flickr.Net.Bases;

namespace Flickr.Net.Internals;

/// <summary>
/// The response returned by the <see cref="IFlickrTest.EchoAsync(Dictionary{string, string},
/// CancellationToken)"/> method.
/// </summary>
public sealed class EchoResponseDictionary : Dictionary<string, string>, IFlickrEntity;