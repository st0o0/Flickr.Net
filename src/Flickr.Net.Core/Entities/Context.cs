namespace Flickr.Net.Core.Entities;

/// <summary>
/// The context of the current photo, as returned by <see cref="IFlickrPhotos.GetContextAsync(string, CancellationToken)"/>, <see
/// cref="IFlickrPhotosets.GetContextAsync(string, string, CancellationToken)"/> and <see cref="IFlickrGroupsPools.GetContextAsync(string, string, CancellationToken)"/> methods.
/// </summary>
public sealed class Context : IFlickrParsable
{
    /// <summary>
    /// The number of photos in the current context, e.g. Group, Set or photostream.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// The next photo in the context.
    /// </summary>
    public ContextPhoto NextPhoto { get; set; }

    /// <summary>
    /// The previous photo in the context.
    /// </summary>
    public ContextPhoto PreviousPhoto { get; set; }

    void IFlickrParsable.Load(XmlReader reader)
    {
        while (reader.NodeType != XmlNodeType.EndElement)
        {
            switch (reader.LocalName)
            {
                case "count":
                    Count = reader.ReadElementContentAsInt();
                    break;

                case "prevphoto":
                    PreviousPhoto = new ContextPhoto();
                    ((IFlickrParsable)PreviousPhoto).Load(reader);
                    if (PreviousPhoto.PhotoId == "0")
                    {
                        PreviousPhoto = null;
                    }

                    break;

                case "nextphoto":
                    NextPhoto = new ContextPhoto();
                    ((IFlickrParsable)NextPhoto).Load(reader);
                    if (NextPhoto.PhotoId == "0")
                    {
                        NextPhoto = null;
                    }

                    break;
            }
        }
    }
}