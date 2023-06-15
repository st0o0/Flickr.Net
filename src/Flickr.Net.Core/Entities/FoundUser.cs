namespace Flickr.Net.Core.Entities;

/// <summary>
/// Contains details of a user
/// </summary>
public sealed class FoundUser : IFlickrParsable
{
    /// <summary>
    /// The ID of the found user.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// The username of the found user.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// The full name of the user. Only returned by <see
    /// cref="IFlickrOAuth.GetAccessTokenAsync(OAuthRequestToken, string, CancellationToken)"/>.
    /// </summary>
    public string FullName { get; set; }

    void IFlickrParsable.Load(XmlReader reader)
    {
        if (reader.LocalName != "user")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "nsid":
                case "id":
                    UserId = reader.Value;
                    break;

                case "username":
                    UserName = reader.Value;
                    break;

                case "fullname":
                    FullName = reader.Value;
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();

        if (reader.NodeType != XmlNodeType.EndElement)
        {
            UserName = reader.ReadElementContentAsString();
            reader.Skip();
        }
    }
}