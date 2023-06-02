﻿using Flickr.Net.Core.Entities.Interfaces;

namespace Flickr.Net.Core.Entities.Collections;

/// <summary>
/// The information about the number of photos a user has.
/// </summary>
public sealed class PhotoCountCollection : System.Collections.ObjectModel.Collection<PhotoCount>, IFlickrParsable
{
    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        if (reader.LocalName != "photocounts")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        reader.Read();

        while (reader.LocalName == "photocount")
        {
            PhotoCount c = new();
            ((IFlickrParsable)c).Load(reader);
            Add(c);
        }

        // Skip to next element (if any)
        reader.Skip();
    }
}

/// <summary>
/// The specifics of a particular count.
/// </summary>
public sealed class PhotoCount : IFlickrParsable
{
    /// <summary>Total number of photos between the FromDate and the ToDate.</summary>
    /// <remarks/>
    public int Count { get; set; }

    /// <summary>The From date as a <see cref="DateTime"/> object.</summary>
    public DateTime FromDate { get; set; }

    /// <summary>The To date as a <see cref="DateTime"/> object.</summary>
    public DateTime ToDate { get; set; }

    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        if (reader.LocalName != "photocount")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "count":
                    Count = int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                case "fromdate":
                    FromDate = System.Text.RegularExpressions.Regex.IsMatch(reader.Value, "^\\d+$") ? UtilityMethods.UnixTimestampToDate(reader.Value) : UtilityMethods.MySqlToDate(reader.Value);
                    break;

                case "todate":
                    ToDate = System.Text.RegularExpressions.Regex.IsMatch(reader.Value, "^\\d+$") ? UtilityMethods.UnixTimestampToDate(reader.Value) : UtilityMethods.MySqlToDate(reader.Value);
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();
    }
}