﻿using Flickr.Net.Core.Entities.Interfaces;
using System.Xml;

namespace Flickr.Net.Core.Entities;

/// <summary>
/// Contains the raw response from Flickr when an unknown method has been called. Used by <see cref="Flickr.TestGeneric"/>.
/// </summary>
public sealed class UnknownResponse : IFlickrParsable
{
    /// <summary>
    /// The response from Flickr.
    /// </summary>
    public string ResponseXml { get; set; }

    /// <summary>
    /// Gets a <see cref="XmlDocument"/> containing the response XML.
    /// </summary>
    /// <returns></returns>
    public XmlDocument GetXmlDocument()
    {
        var document = new XmlDocument();
        document.LoadXml(ResponseXml);

        return document;
    }

    /// <summary>
    /// Gets an attribute value from the given response.
    /// </summary>
    /// <param name="element">The element name to find.</param>
    /// <param name="attribute">The attribute of the element to return.</param>
    /// <returns>The string value of the given attribute, if found.</returns>
    public string GetAttributeValue(string element, string attribute)
    {
        XmlDocument doc = GetXmlDocument();
        XmlNode node = doc.SelectSingleNode("//" + element + "/@" + attribute);
        if (node != null)
        {
            return node.Value;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Gets an text value of an element from the given response.
    /// </summary>
    /// <param name="element">The element name to find.</param>
    /// <returns>The string value of the given element, if found.</returns>
    public string GetElementValue(string element)
    {
        XmlDocument doc = GetXmlDocument();
        XmlNode node = doc.SelectSingleNode("//" + element + "[1]");
        if (node != null)
        {
            return node.InnerText;
        }
        else
        {
            return null;
        }
    }

    void IFlickrParsable.Load(XmlReader reader)
    {
        ResponseXml = reader.ReadOuterXml();
    }

    /// <summary>
    /// Gets an array of text values of an element from the given response.
    /// </summary>
    /// <param name="elementName">The element name to find.</param>
    /// <returns>An array of string values.</returns>
    public string[] GetElementArray(string elementName)
    {
        List<string> array = new();
        foreach (XmlNode n in GetXmlDocument().SelectNodes("//" + elementName))
        {
            array.Add(n.InnerText);
        }
        return array.ToArray();
    }

    /// <summary>
    /// Gets an array of text values of an element's attribute from the given response.
    /// </summary>
    /// <param name="elementName">The element name to find.</param>
    /// <param name="attributeName">The attribute name to find on the matching element.</param>
    /// <returns>An array of string values.</returns>
    public string[] GetElementArray(string elementName, string attributeName)
    {
        List<string> array = new();
        foreach (XmlNode n in GetXmlDocument().SelectNodes("//" + elementName + "/@" + attributeName))
        {
            array.Add(n.InnerText);
        }
        return array.ToArray();
    }
}