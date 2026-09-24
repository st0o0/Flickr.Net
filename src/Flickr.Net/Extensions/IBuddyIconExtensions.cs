using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;

/// <summary>Extension methods for constructing buddy icon (avatar) URLs.</summary>
public static class IBuddyIconExtensions
{
    public static string ToBuddyIconUrl(this IBuddyIcon value)
    {
        return value switch
        {
            Item { OwnerServer: not null, OwnerFarm: not null, OwnerId: not null } item => UtilityMethods.BuddyIcon(
                item.OwnerServer, item.OwnerFarm, item.OwnerId),
            Contact { IconServer: not null } contact => UtilityMethods.BuddyIcon(contact.IconServer,
                contact.IconFarm.ToString(), contact.Id),
            Gallery { IconServer: not null, Owner: not null } gallery => UtilityMethods.BuddyIcon(gallery.IconServer,
                gallery.IconFarm.ToString(),
                gallery.Owner),
            Group { IconServer: not null } group => UtilityMethods.BuddyIcon(group.IconServer,
                group.IconFarm.ToString(), group.Id),
            GroupInfo { IconServer: not null } groupInfo => UtilityMethods.BuddyIcon(groupInfo.IconServer,
                groupInfo.IconFarm.ToString(),
                groupInfo.Id),
            Member { IconServer: not null, IconFarm: not null } member => UtilityMethods.BuddyIcon(member.IconServer,
                member.IconFarm, member.Id),
            Person { IconServer: not null } person => UtilityMethods.BuddyIcon(person.IconServer,
                person.IconFarm.ToString(), person.Id),
            PhotoInfo { Owner.IconServer: not null } photoInfo => UtilityMethods.BuddyIcon(
                photoInfo.Owner.IconServer, photoInfo.Owner.IconFarm.ToString(), photoInfo.Owner.Id),
            Comment { IconServer: not null, Author: not null } comment => UtilityMethods.BuddyIcon(comment.IconServer,
                comment.IconFarm.ToString(), comment.Author),
            PhotoPerson { IconServer: not null } photoPerson => UtilityMethods.BuddyIcon(photoPerson.IconServer,
                photoPerson.IconFarm.ToString(), photoPerson.Id),
            Topic { AuthorIconServer: not null, AuthorIconFarm: not null, Author: not null } topic =>
                UtilityMethods.BuddyIcon(topic.AuthorIconServer, topic.AuthorIconFarm, topic.Author),
            Reply { IconServer: not null, Author: not null } reply => UtilityMethods.BuddyIcon(reply.IconServer,
                reply.IconFarm.ToString(), reply.Author),
            _ => string.Empty
        };
    }
}