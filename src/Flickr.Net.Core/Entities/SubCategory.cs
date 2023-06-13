namespace Flickr.Net.Core.Entities;

/// <summary>
/// Holds details of a sub category, including its id, name and the number of groups in it.
/// </summary>
public sealed class SubCategory : IFlickrParsable
{
    /// <summary>
    /// The id of the category.
    /// </summary>
    public string SubcategoryId { get; set; }

    /// <summary>
    /// The name of the category.
    /// </summary>
    public string SubcategoryName { get; set; }

    /// <summary>
    /// The number of groups found within the category.
    /// </summary>
    public int GroupCount { get; set; }

    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        if (reader.LocalName != "category")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "id":
                    SubcategoryId = reader.Value;
                    break;

                case "name":
                    SubcategoryName = reader.Value;
                    break;

                case "count":
                    GroupCount = int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();
    }
}