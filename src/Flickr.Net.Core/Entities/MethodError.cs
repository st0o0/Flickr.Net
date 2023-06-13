namespace Flickr.Net.Core.Entities;

/// <summary>
/// A possible error that a method can return.
/// </summary>
public sealed class MethodError : IFlickrParsable
{
    /// <summary>
    /// The code for the error.
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// The message for a method error.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// The description of a method error.
    /// </summary>
    public string Description { get; set; }

    void IFlickrParsable.Load(XmlReader reader)
    {
        if (reader.LocalName != "error")
        {
            return;
        }

        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "code":
                    Code = int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                case "message":
                    Message = reader.Value;
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();

        if (reader.NodeType == XmlNodeType.Text)
        {
            Description = reader.ReadContentAsString();
            reader.Read();
        }
    }
}