namespace Flickr.Net.Core.Entities;

/// <summary>
/// A simple tag class, containing a tag name and optional count (for <see cref="IFlickrTags.GetListUserPopularAsync(string, int?, CancellationToken)"/>)
/// </summary>
public sealed class Tag : IFlickrParsable
{
    /// <summary>
    /// The name of the tag.
    /// </summary>
    public string TagName { get; set; }

    /// <summary>
    /// The poularity of the tag. Will be 0 if not returned via <see cref="IFlickrTags.GetListUserPopularAsync(string, int?, CancellationToken)"/>
    /// </summary>
    public int Count { get; set; }

    void IFlickrParsable.Load(XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "count":
                    Count = reader.ReadContentAsInt();
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();

        TagName = reader.ReadContentAsString();

        reader.Read();
    }
}