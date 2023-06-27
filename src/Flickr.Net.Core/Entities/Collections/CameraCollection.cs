﻿namespace Flickr.Net.Core.Entities.Collections;

/// <summary>
/// A collection of camera models for a particular brand.
/// </summary>
public class CameraCollection : Collection<Camera>, IFlickrParsable
{
    void IFlickrParsable.Load(XmlReader reader)
    {
        if (reader.LocalName != "cameras")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        reader.Read();

        while (reader.LocalName == "camera")
        {
            Camera c = new();
            ((IFlickrParsable)c).Load(reader);
            Add(c);
        }

        // Skip to next element (if any)
        reader.Skip();
    }
}