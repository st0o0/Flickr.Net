//using Flickr.Net.Core.Internals.Attributes;
//using Newtonsoft.Json;

//namespace Flickr.Net.Core.Entities;

///// <summary>
///// Contains details of a user
///// </summary>
//[FlickrJsonPropertyName("user")]
//public sealed class FoundUser : IFlickrParsable
//{
//    /// <summary>
//    /// The ID of the found user.
//    /// </summary>
//    [JsonProperty("nsid")]
//    public string UserId { get; set; }

// ///
// <summary>
// /// The username of the found user. ///
// </summary>
// [JsonProperty("username")] public string UserName { get; set; }

// /// <summary> /// The full name of the user. Only returned by <see ///
// cref="IFlickrOAuth.GetAccessTokenAsync(OAuthRequestToken, string, CancellationToken)"/>. ///
// </summary> [JsonProperty("fullname")] public string FullName { get; set; }

// void IFlickrParsable.Load(XmlReader reader) { if (reader.LocalName != "user") {
// UtilityMethods.CheckParsingException(reader); }

// while (reader.MoveToNextAttribute()) { switch (reader.LocalName) { case "nsid": case "id": UserId
// = reader.Value; break;

// case "username": UserName = reader.Value; break;

// case "fullname": FullName = reader.Value; break;

// default: UtilityMethods.CheckParsingException(reader); break; } }

// reader.Read();

//        if (reader.NodeType != XmlNodeType.EndElement)
//        {
//            UserName = reader.ReadElementContentAsString();
//            reader.Skip();
//        }
//    }
//}