//namespace Flickr.Net.Core.Entities.Collections;

///// <summary>
///// Returned by <see cref="IFlickrGroups.SearchAsync(string, int, int, CancellationToken)"/> methods.
///// </summary>
//public sealed class GroupSearchResultCollection : System.Collections.ObjectModel.Collection<GroupSearchResult>, IFlickrParsable
//{
//    /// <summary>
//    /// The current page that the group search results represents.
//    /// </summary>
//    public int Page { get; set; }

// ///
// <summary>
// /// The total number of pages this search would return. ///
// </summary>
// public int Pages { get; set; }

// ///
// <summary>
// /// The number of groups returned per photo. ///
// </summary>
// public int PerPage { get; set; }

// ///
// <summary>
// /// The total number of groups that where returned for the search. ///
// </summary>
// public int Total { get; set; }

// void IFlickrParsable.Load(XmlReader reader) { if (reader.LocalName != "groups") {
// UtilityMethods.CheckParsingException(reader); }

// while (reader.MoveToNextAttribute()) { switch (reader.LocalName) { case "page": Page =
// int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo); break;

// case "perpage": case "per_page": PerPage = int.Parse(reader.Value,
// System.Globalization.NumberFormatInfo.InvariantInfo); break;

// case "total": Total = int.Parse(reader.Value,
// System.Globalization.NumberFormatInfo.InvariantInfo); break;

// case "pages": Pages = int.Parse(reader.Value,
// System.Globalization.NumberFormatInfo.InvariantInfo); break;

// default: UtilityMethods.CheckParsingException(reader); break; } }

// reader.Read();

// while (reader.LocalName == "group") { GroupSearchResult r = new();
// ((IFlickrParsable)r).Load(reader); Add(r); }

//        // Skip to next element (if any)
//        reader.Skip();
//    }
//}
