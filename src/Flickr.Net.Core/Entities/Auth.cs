namespace Flickr.Net.Core.Entities;

/// <summary>
/// Successful authentication returns a <see cref="Auth"/> object.
/// </summary>
[Serializable]
public sealed class Auth : IFlickrParsable
{
    /// <summary>
    /// The authentication token returned by the <see cref="Flickr.AuthGetToken"/> or <see
    /// cref="Flickr.AuthCheckToken(string)"/> methods.
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// The permissions the current token allows the application to perform.
    /// </summary>
    public AuthLevel Permissions { get; set; }

    /// <summary>
    /// The <see cref="User"/> object associated with the token. Readonly.
    /// </summary>
    public FoundUser User { get; set; }

    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        reader.Read();

        while (reader.LocalName != "auth" && reader.LocalName != "oauth")
        {
            switch (reader.LocalName)
            {
                case "token":
                    Token = reader.ReadElementContentAsString();
                    break;

                case "perms":
                    Permissions = (AuthLevel)Enum.Parse(typeof(AuthLevel), reader.ReadElementContentAsString(), true);
                    break;

                case "user":
                    User = new FoundUser();
                    ((IFlickrParsable)User).Load(reader);
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    reader.Skip();
                    break;
            }
        }
    }
}