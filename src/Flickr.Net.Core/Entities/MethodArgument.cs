namespace Flickr.Net.Core.Entities;

/// <summary>
/// An argument for a method.
/// </summary>
public sealed class MethodArgument : IFlickrParsable
{
    /// <summary>
    /// The name of the argument.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Is the argument optional or not.
    /// </summary>
    public bool IsOptional { get; set; }

    /// <summary>
    /// The description of the argument.
    /// </summary>
    public string Description { get; set; }

    void IFlickrParsable.Load(XmlReader reader)
    {
        if (reader.LocalName != "argument")
        {
            return;
        }

        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "name":
                    Name = reader.Value;
                    break;

                case "optional":
                    IsOptional = reader.Value == "1";
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