namespace Flickr.Net.Core.Entities;

/// <summary>
/// Raw tags, as returned by the <see cref="IFlickrTags.GetListUserRawAsync(string,
/// CancellationToken)"/> method.
/// </summary>
public sealed class RawTag : IFlickrParsable
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public RawTag()
    {
        RawTags = new Collection<string>();
    }

    /// <summary>
    /// An array of strings containing the raw tags returned by the method.
    /// </summary>
    public Collection<string> RawTags { get; set; }

    /// <summary>
    /// The clean tag.
    /// </summary>
    public string CleanTag { get; set; }

    void IFlickrParsable.Load(XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "clean":
                    CleanTag = reader.ReadContentAsString();
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();

        while (reader.LocalName == "raw")
        {
            RawTags.Add(reader.ReadElementContentAsString());
        }

        reader.Read();
    }
}