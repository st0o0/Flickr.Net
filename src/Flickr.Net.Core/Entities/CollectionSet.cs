//namespace Flickr.Net.Core.Entities;

///// <summary>
///// </summary>
//public sealed class CollectionSet : IFlickrParsable
//{
//    /// <remarks/>
//    /// <summary>
//    /// Gets or sets the set id.
//    /// </summary>
//    public string SetId { get; set; }

// ///
// <remarks/>
// ///
// <summary>
// /// Gets or sets the title. ///
// </summary>
// public string Title { get; set; }

// ///
// <remarks/>
// ///
// <summary>
// /// Gets or sets the description. ///
// </summary>
// public string Description { get; set; }

// void IFlickrParsable.Load(XmlReader reader) { if (reader.LocalName != "set") {
// UtilityMethods.CheckParsingException(reader); }

// while (reader.MoveToNextAttribute()) { switch (reader.LocalName) { case "id": SetId =
// reader.Value; break;

// case "title": Title = reader.Value; break;

// case "description": Description = reader.Value; break;

// default: UtilityMethods.CheckParsingException(reader); break; } }

//        reader.Skip();
//    }
//}