﻿namespace Flickr.Net.Core.Entities.Collections;

/// <summary>
/// The collection of CSV files containing archived stats available for download from Flickr.
/// </summary>
/// <remarks>
/// Only supported until the 1st June 2010.
/// </remarks>
public sealed class CsvFileCollection : System.Collections.ObjectModel.Collection<CsvFile>, IFlickrParsable
{
    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        reader.ReadToDescendant("csv");

        while (reader.LocalName == "csv" && reader.NodeType != System.Xml.XmlNodeType.EndElement)
        {
            CsvFile file = new();
            ((IFlickrParsable)file).Load(reader);
            Add(file);
        }
    }
}