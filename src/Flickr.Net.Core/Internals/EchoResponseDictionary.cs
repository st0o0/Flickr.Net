namespace Flickr.Net.Core.Internals;

/// <summary>
/// The response returned by the <see cref="IFlickrTest.EchoAsync(Dictionary{string, string},
/// CancellationToken)"/> method.
/// </summary>
[Serializable]
public sealed class EchoResponseDictionary : Dictionary<string, string>, IFlickrParsable
{
    void IFlickrParsable.Load(XmlReader reader)
    {
        while (reader.NodeType != XmlNodeType.None && reader.NodeType != XmlNodeType.EndElement)
        {
            Add(reader.Name, reader.ReadElementContentAsString());
        }
    }
}