namespace Flickr.Net.Core;

// TODO:
public partial class Flickr
{
    /// <summary>
    /// Get a users profile properties.
    /// </summary>
    /// <param name="userId">The id of the user to get the profile for.</param>
    /// <returns>A <see cref="Profile"/> instance containing the details of the users profile.</returns>
    public async Task<Profile> ProfileGetProfileAsync(string userId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.profile.getProfile" },
            { "user_id", userId }
        };

        return await GetResponseAsync<Profile>(parameters, cancellationToken);
    }
}