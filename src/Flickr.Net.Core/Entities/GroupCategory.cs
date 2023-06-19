//namespace Flickr.Net.Core.Entities;

///// <summary>
///// Contains details of a category, including groups belonging to the category and sub categories.
///// </summary>
//public sealed class GroupCategory : IFlickrParsable
//{
//    /// <summary>
//    /// Default constructor.
//    /// </summary>
//    public GroupCategory()
//    {
//        Subcategories = new Collection<SubCategory>();
//        //Groups = new Collection<Group>();
//    }

// ///
// <summary>
// /// The name for the category. ///
// </summary>
// public string CategoryName { get; set; }

// ///
// <summary>
// /// A forward slash delimited list of the parents of the current group. ///
// </summary>
// ///
// <remarks>Can be matched against the list of PathIds to jump directly to a parent group.</remarks>
// ///
// <example>
// /// Group Id 91, Romance will return "/Life/Romance" as the Path and "/90/91" as its PathIds ///
// </example>
// public string Path { get; set; }

// ///
// <summary>
// /// A forward slash delimited list of the ids of the parents of the current group. ///
// </summary>
// ///
// <remarks>Can be matched against the Path to jump directly to a parent group.</remarks>
// ///
// <example>
// /// Group Id 91, Romance will return "/Life/Romance" as the Path and "/90/91" as its PathIds ///
// </example>
// public string PathIds { get; set; }

// /// <summary> /// An array of <see cref="SubCategory"/> items. /// </summary> public
// Collection<SubCategory> Subcategories { get; set; }

// /// <summary> /// An array of <see cref="Group"/> items, listing the groups within this category.
// /// </summary> //public System.Collections.ObjectModel.Collection<Group> Groups { get; set; }

// void IFlickrParsable.Load(System.Xml.XmlReader reader) { if (reader.LocalName != "category") {
// UtilityMethods.CheckParsingException(reader); }

// while (reader.MoveToNextAttribute()) { switch (reader.LocalName) { case "name": CategoryName =
// reader.Value; break;

// case "path": Path = reader.Value; break;

// case "pathids": PathIds = reader.Value; break;

// default: UtilityMethods.CheckParsingException(reader); break; } }

// reader.Read();

// while (reader.LocalName == "subcat" || reader.LocalName == "group") { if (reader.LocalName ==
// "subcat") { SubCategory c = new(); ((IFlickrParsable)c).Load(reader); Subcategories.Add(c); }
// else { //Group s = new(); //((IFlickrParsable)s).Load(reader); //Groups.Add(s); } }

//        // Skip to next element (if any)
//        reader.Skip();
//    }
//}
