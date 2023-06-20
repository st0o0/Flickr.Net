//using Flickr.Net.Core.Internals.JsonConverters;
//using Newtonsoft.Json;

//namespace Flickr.Net.Core.Entities;

///// <summary>
///// A machine tag value and its usage.
///// </summary>
//public sealed class Value : IFlickrParsable
//{
//    /// <summary>
//    /// The usage of this machine tag value.
//    /// </summary>
//    [JsonProperty("usage")]
//    public int Usage { get; set; }

// ///
// <summary>
// /// The namespace for this value. ///
// </summary>
// [JsonProperty("namespace")] public string Namespace { get; set; }

// ///
// <summary>
// /// The predicate name for this value. ///
// </summary>
// [JsonProperty("predicate")] public string Predicate { get; set; }

// ///
// <summary>
// /// The text of this value. ///
// </summary>
// [JsonProperty("_content")] public string Content { get; set; }

// ///
// <summary>
// /// The date this machine tag was first used. ///
// </summary>
// [JsonProperty("first_added")] [JsonConverter(typeof(TimestampToDateTimeConverter))] public
// DateTime? FirstAdded { get; set; }

// ///
// <summary>
// /// The date this machine tag was last added. ///
// </summary>
// [JsonProperty("last_added")] [JsonConverter(typeof(TimestampToDateTimeConverter))] public
// DateTime? LastUsed { get; set; }

// ///
// <summary>
// /// The full machine tag for this value. ///
// </summary>
// public string ToMachineTagString() =&gt; Namespace + ":" + Predicate + "=" + Content;

// void IFlickrParsable.Load(System.Xml.XmlReader reader) { while (reader.MoveToNextAttribute()) {
// switch (reader.LocalName) { case "usage": Usage = reader.ReadContentAsInt(); break;

// case "predicate": Predicate = reader.Value; break;

// case "namespace": Namespace = reader.Value; break;

// case "first_added": FirstAdded = UtilityMethods.UnixTimestampToDate(reader.Value); break;

// case "last_added": LastUsed = UtilityMethods.UnixTimestampToDate(reader.Value); break; } }

// reader.Read();

// if (reader.NodeType == System.Xml.XmlNodeType.Text) { Content = reader.ReadContentAsString(); }

//        reader.Read();
//    }
//}