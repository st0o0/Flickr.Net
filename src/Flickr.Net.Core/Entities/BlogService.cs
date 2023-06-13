﻿namespace Flickr.Net.Core.Entities;

/// <summary>
/// Details of the blog services supported by Flickr. e.g. Twitter, Blogger etc.
/// </summary>
public sealed class BlogService : IFlickrParsable
{
    /// <summary>
    /// The unique ID for the blog service supported by Flickr.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The name of the blog service supported by Flickr.
    /// </summary>
    public string Name { get; set; }

    void IFlickrParsable.Load(XmlReader reader)
    {
        if (reader.LocalName != "service")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "id":
                    Id = reader.Value;
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();

        Name = reader.ReadContentAsString();

        reader.Skip();
    }
}