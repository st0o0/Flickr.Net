using System.Xml;

namespace FlickrNet.Core.Entities.Collections;

/// <remarks/>
public sealed class PhotoCollection : PagedPhotoCollection, IFlickrParsable
{
    void IFlickrParsable.Load(XmlReader reader)
    {
        if (reader.LocalName != "photos")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "total":
                    Total = string.IsNullOrEmpty(reader.Value) ? 0 : int.Parse(reader.Value, System.Globalization.CultureInfo.InvariantCulture);
                    break;

                case "perpage":
                case "per_page":
                    PerPage = string.IsNullOrEmpty(reader.Value) ? 0 : int.Parse(reader.Value, System.Globalization.CultureInfo.InvariantCulture);
                    break;

                case "page":
                    Page = string.IsNullOrEmpty(reader.Value) ? 0 : int.Parse(reader.Value, System.Globalization.CultureInfo.InvariantCulture);
                    break;

                case "pages":
                    Pages = string.IsNullOrEmpty(reader.Value) ? 0 : int.Parse(reader.Value, System.Globalization.CultureInfo.InvariantCulture);
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();

        while (reader.LocalName == "photo")
        {
            Photo p = new();
            ((IFlickrParsable)p).Load(reader);
            if (!string.IsNullOrEmpty(p.PhotoId))
            {
                Add(p);
            }
        }

        // Skip to next element (if any)
        reader.Skip();
    }
}