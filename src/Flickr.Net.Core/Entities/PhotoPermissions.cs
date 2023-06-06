using System.Xml;

namespace Flickr.Net.Core.Entities;

/// <summary>
/// Permissions for the selected photo.
/// </summary>
public sealed class PhotoPermissions : IFlickrParsable
{
    /// <remarks/>
    /// <summary>
    /// Gets or sets the photo id.
    /// </summary>
    public string PhotoId { get; set; }

    /// <remarks/>
    /// <summary>
    /// Gets or sets a value indicating whether is public.
    /// </summary>
    public bool IsPublic { get; set; }

    /// <remarks/>
    /// <summary>
    /// Gets or sets a value indicating whether is friend.
    /// </summary>
    public bool IsFriend { get; set; }

    /// <remarks/>
    /// <summary>
    /// Gets or sets a value indicating whether is family.
    /// </summary>
    public bool IsFamily { get; set; }

    /// <remarks/>
    /// <summary>
    /// Gets or sets the permission comment.
    /// </summary>
    public PermissionComment PermissionComment { get; set; }

    /// <remarks/>
    /// <summary>
    /// Gets or sets the permission add meta.
    /// </summary>
    public PermissionAddMeta PermissionAddMeta { get; set; }

    void IFlickrParsable.Load(XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "id":
                    PhotoId = reader.Value;
                    break;

                case "ispublic":
                    IsPublic = reader.Value == "1";
                    break;

                case "isfamily":
                    IsFamily = reader.Value == "1";
                    break;

                case "isfriend":
                    IsFriend = reader.Value == "1";
                    break;

                case "permcomment":
                    PermissionComment = (PermissionComment)Enum.Parse(typeof(PermissionComment), reader.Value, true);
                    break;

                case "permaddmeta":
                    PermissionAddMeta = (PermissionAddMeta)Enum.Parse(typeof(PermissionAddMeta), reader.Value, true);
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();
    }
}