namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrProfile
{
    async Task<Profile> IFlickrProfile.GetProfileAsync(string userId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.profile.getProfile" },
            { "user_id", userId }
        };

        return await GetResponseAsync<Profile>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr profile.
/// </summary>
public interface IFlickrProfile
{
    /// <summary>
    /// Get a users profile properties.
    /// </summary>
    /// <param name="userId">The id of the user to get the profile for.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A <see cref="Profile"/> instance containing the details of the users profile.</returns>
    Task<Profile> GetProfileAsync(string userId, CancellationToken cancellationToken = default);
}