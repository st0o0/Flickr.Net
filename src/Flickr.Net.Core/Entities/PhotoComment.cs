﻿namespace Flickr.Net.Core.Entities;

/// <summary>
/// Contains the details of a comment made on a photo.
/// returned by the <see cref="Flickr.PhotosCommentsGetList"/> method.
/// </summary>
public sealed class PhotoComment : IFlickrParsable
{
    /// <summary>
    /// The comment id of this comment.
    /// </summary>
    public string CommentId { get; set; }

    /// <summary>
    /// The user id of the author of the comment.
    /// </summary>
    public string AuthorUserId { get; set; }

    /// <summary>
    /// The username (screen name) of the author of the comment.
    /// </summary>
    public string AuthorUserName { get; set; }

    /// <summary>
    /// The real name of the comment author, if known.
    /// </summary>
    public string AuthorRealName { get; set; }

    /// <summary>
    /// The permalink to the comment on the photos web page.
    /// </summary>
    public string Permalink { get; set; }

    /// <summary>
    /// The date and time that the comment was created.
    /// </summary>
    public DateTime DateCreated { get; set; }

    /// <summary>
    /// The server for the commenting users buddy icon.
    /// </summary>
    public string IconServer { get; set; }

    /// <summary>
    /// The farm for the commenting users buddy icon.
    /// </summary>
    public string IconFarm { get; set; }

    /// <summary>
    /// The comment authors buddy icon.
    /// </summary>
    public string AuthorBuddyIcon
    {
        get
        {
            return UtilityMethods.BuddyIcon(IconServer, IconFarm, AuthorUserId);
        }
    }

    /// <summary>
    /// The path alias for the comment owner's page.
    /// </summary>
    public string AuthorPathAlias { get; set; }

    /// <summary>
    /// The comment text (can contain HTML).
    /// </summary>
    public string CommentHtml { get; set; }

    /// <summary>
    /// The account of the author of this comment has been deleted.
    /// </summary>
    public bool AuthorIsDeleted { get; set; }

    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        if (reader.LocalName != "comment")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "id":
                    CommentId = reader.Value;
                    break;

                case "author":
                    AuthorUserId = reader.Value;
                    break;

                case "authorname":
                    AuthorUserName = reader.Value;
                    break;

                case "permalink":
                    Permalink = reader.Value;
                    break;

                case "datecreate":
                    DateCreated = UtilityMethods.UnixTimestampToDate(reader.Value);
                    break;

                case "iconserver":
                    IconServer = reader.Value;
                    break;

                case "iconfarm":
                    IconFarm = reader.Value;
                    break;

                case "path_alias":
                    AuthorPathAlias = reader.Value;
                    break;

                case "realname":
                    AuthorRealName = reader.Value;
                    break;

                case "author_is_deleted":
                    AuthorIsDeleted = reader.Value == "1";
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();

        CommentHtml = reader.ReadContentAsString();

        reader.Skip();
    }
}