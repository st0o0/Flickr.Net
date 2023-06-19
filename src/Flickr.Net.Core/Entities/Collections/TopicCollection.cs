﻿//using Flickr.Net.Core.Exceptions;

//namespace Flickr.Net.Core.Entities.Collections;

///// <summary>
///// A collection of topics for a particular group.
///// </summary>
//public class TopicCollection : System.Collections.ObjectModel.Collection<Topic>, IFlickrParsable
//{
//    /// <summary>
//    /// The id of the group the topics belong to.
//    /// </summary>
//    public string GroupId { get; set; }

// ///
// <summary>
// /// The path alias for the group's url. ///
// </summary>
// public string PathAlias { get; set; }

// ///
// <summary>
// /// The server for the group's icon. ///
// </summary>
// public string GroupIconServer { get; set; }

// ///
// <summary>
// /// The farm for the group's icon. ///
// </summary>
// public string GroupIconFarm { get; set; }

// ///
// <summary>
// /// The name of the group the topics belong to. ///
// </summary>
// public string GroupName { get; set; }

// ///
// <summary>
// /// The number of members in the group. ///
// </summary>
// public int MemberCount { get; set; }

// ///
// <summary>
// /// The privacy setting for this group. ///
// </summary>
// public PoolPrivacy Privacy { get; set; }

// ///
// <summary>
// /// The default language of this group. ///
// </summary>
// public string Language { get; set; }

// ///
// <summary>
// /// True is the pool is moderated. ///
// </summary>
// public bool IsPoolModerated { get; set; }

// ///
// <summary>
// /// The total number of topics in this group. ///
// </summary>
// public int Total { get; set; }

// ///
// <summary>
// /// The number of topics per page. ///
// </summary>
// public int PerPage { get; set; }

// ///
// <summary>
// /// The page of topics that was returned. ///
// </summary>
// public int Page { get; set; }

// ///
// <summary>
// /// The total number of pages of topics that are in this group. ///
// </summary>
// public int Pages { get; set; }

// ///
// <summary>
// /// The URL for the group icon. ///
// </summary>
// public string GroupIconUrl { get { return UtilityMethods.BuddyIcon(GroupIconServer,
// GroupIconFarm, GroupId); } }

// void IFlickrParsable.Load(System.Xml.XmlReader reader) { if (reader == null) { throw new
// ArgumentNullException(nameof(reader)); }

// if (reader.LocalName != "topics") { throw new ResponseXmlException("Unknown initial element \"" +
// reader.LocalName + "\". Expecting \"topics\"."); }

// while (reader.MoveToNextAttribute()) { switch (reader.LocalName) { case "group_id": GroupId =
// reader.Value; break;

// case "iconserver": GroupIconServer = reader.Value; break;

// case "iconfarm": GroupIconFarm = reader.Value; break;

// case "name": GroupName = reader.Value; break;

// case "members": MemberCount = reader.ReadContentAsInt(); break;

// case "privacy": Privacy = (PoolPrivacy)reader.ReadContentAsInt(); break;

// case "lang": Language = reader.Value; break;

// case "ispoolmoderated": IsPoolModerated = reader.Value == "1"; break;

// case "total": Total = reader.ReadContentAsInt(); break;

// case "pages": Pages = reader.ReadContentAsInt(); break;

// case "page": Page = reader.ReadContentAsInt(); break;

// case "per_page": PerPage = reader.ReadContentAsInt(); break;

// case "path_alias": PathAlias = reader.Value == "" ? null : reader.Value; break;

// default: UtilityMethods.CheckParsingException(reader); break; } }

// reader.Read();

//        while (reader.LocalName == "topic")
//        {
//            Topic topic = new();
//            ((IFlickrParsable)topic).Load(reader);
//            Add(topic);
//        }
//    }
//}  