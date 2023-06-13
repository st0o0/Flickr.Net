namespace Flickr.Net.Core.Entities;

/// <summary>
/// A method supported by the Flickr API.
/// </summary>
/// <remarks>
/// See <a href="https://www.flickr.com/services/api">Flickr API Documentation</a> for a complete
/// list of methods.
/// </remarks>
public sealed class Method : IFlickrParsable
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public Method()
    {
        Arguments = new System.Collections.ObjectModel.Collection<MethodArgument>();
        Errors = new System.Collections.ObjectModel.Collection<MethodError>();
    }

    /// <summary>
    /// The name of the method.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Does the method require the call to be authenticated.
    /// </summary>
    public bool NeedsLogin { get; set; }

    /// <summary>
    /// Does the method request the call to be signed.
    /// </summary>
    public bool NeedsSigning { get; set; }

    /// <summary>
    /// The minimum level of permissions required for this method call.
    /// </summary>
    public MethodPermission RequiredPermissions { get; set; }

    /// <summary>
    /// The description of the method.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// An example response for the method.
    /// </summary>
    public string Response { get; set; }

    /// <summary>
    /// An explanation of the example response for the method.
    /// </summary>
    public string Explanation { get; set; }

    /// <summary>
    /// The arguments of the method.
    /// </summary>
    public System.Collections.ObjectModel.Collection<MethodArgument> Arguments { get; set; }

    /// <summary>
    /// The possible errors that could be returned by the method.
    /// </summary>
    public System.Collections.ObjectModel.Collection<MethodError> Errors { get; set; }

    void IFlickrParsable.Load(XmlReader reader)
    {
        if (reader.LocalName != "method")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "name":
                    Name = reader.Value;
                    break;

                case "needslogin":
                    NeedsLogin = reader.Value == "1";
                    break;

                case "needssigning":
                    NeedsSigning = reader.Value == "1";
                    break;

                case "requiredperms":
                    RequiredPermissions = (MethodPermission)int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();

        while (reader.LocalName != "method")
        {
            switch (reader.LocalName)
            {
                case "description":
                    Description = reader.ReadElementContentAsString();
                    break;

                case "response":
                    Response = reader.ReadElementContentAsString();
                    break;

                case "explanation":
                    Explanation = reader.ReadElementContentAsString();
                    break;
            }
        }

        reader.ReadToFollowing("argument");

        while (reader.LocalName == "argument")
        {
            MethodArgument a = new();
            ((IFlickrParsable)a).Load(reader);
            Arguments.Add(a);
        }
        reader.ReadToFollowing("error");

        while (reader.LocalName == "error")
        {
            MethodError e = new();
            ((IFlickrParsable)e).Load(reader);
            Errors.Add(e);
        }
        reader.Read();

        reader.Skip();
    }
}