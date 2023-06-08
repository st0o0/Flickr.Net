namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrPush
{
    async Task<SubscriptionCollection> IFlickrPush.PushGetSubscriptionsAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new() { { "method", "flickr.push.getSubscriptions" } };

        return await GetResponseAsync<SubscriptionCollection>(parameters, cancellationToken);
    }

    async Task<string[]> IFlickrPush.PushGetTopicsAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.push.getTopics" }
        };

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return result.GetElementArray("topic", "name");
    }

    async Task IFlickrPush.PushSubscribeAsync(string topic, string callback, string verify, string verifyToken,
                                  int? leaseSeconds, IEnumerable<int> woeIds, IEnumerable<string> placeIds, double? latitude,
                                  double? longitude, int? radius, RadiusUnit radiusUnits, GeoAccuracy accuracy,
                                  IEnumerable<string> nsids, IEnumerable<string> tags, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        if (string.IsNullOrEmpty(topic))
        {
            throw new ArgumentNullException(nameof(topic));
        }

        if (string.IsNullOrEmpty(callback))
        {
            throw new ArgumentNullException(nameof(callback));
        }

        if (string.IsNullOrEmpty(verify))
        {
            throw new ArgumentNullException(nameof(verify));
        }

        if (topic == "tags" && (tags == null || tags.Any()))
        {
            throw new InvalidOperationException("Must specify at least one tag is using topic of 'tags'");
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.push.subscribe" },
            { "topic", topic },
            { "callback", callback },
            { "verify", verify }
        };

        if (!string.IsNullOrEmpty(verifyToken))
        {
            parameters.Add("verify_token", verifyToken);
        }

        if (leaseSeconds.HasValue && leaseSeconds > 0)
        {
            parameters.Add("lease_seconds",
                           leaseSeconds.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (woeIds != null && woeIds.Any())
        {
            parameters.Add("woe_ids", string.Join(",", woeIds.Select(x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo)).ToArray()));
        }

        if (placeIds != null && placeIds.Any())
        {
            parameters.Add("place_ids", string.Join(",", placeIds));
        }

        if (latitude.HasValue && latitude > 0 && topic == "geo")
        {
            parameters.Add("lat", latitude.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (longitude.HasValue && longitude > 0 && topic == "geo")
        {
            parameters.Add("lon", longitude.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (radius.HasValue && radius > 0 && topic == "geo")
        {
            parameters.Add("radius", radius.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (radiusUnits != RadiusUnit.None && topic == "geo")
        {
            parameters.Add("radius_units", radiusUnits.ToString("d"));
        }

        if (accuracy != GeoAccuracy.None)
        {
            parameters.Add("accuracy", ((int)accuracy).ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (nsids != null && nsids.Any() && topic == "commons")
        {
            parameters.Add("nsids", string.Join(",", nsids.ToArray()));
        }

        if (tags != null && tags.Any() && topic == "tags")
        {
            parameters.Add("tags", string.Join(",", tags.ToArray()));
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task IFlickrPush.PushUnsubscribeAsync(string topic, string callback, string verify, string verifyToken, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        if (string.IsNullOrEmpty(topic))
        {
            throw new ArgumentNullException(nameof(topic));
        }

        if (string.IsNullOrEmpty(callback))
        {
            throw new ArgumentNullException(nameof(callback));
        }

        if (string.IsNullOrEmpty(verify))
        {
            throw new ArgumentNullException(nameof(verify));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.push.unsubscribe" },
            { "topic", topic },
            { "callback", callback },
            { "verify", verify }
        };

        if (!string.IsNullOrEmpty(verifyToken))
        {
            parameters.Add("verif_token", verifyToken);
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr push.
/// </summary>
public interface IFlickrPush
{
    /// <summary>
    /// Get a list of subscriptions for the calling user.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SubscriptionCollection> PushGetSubscriptionsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of topics that are available for subscription.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string[]> PushGetTopicsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Subscribe to a particular topic.
    /// </summary>
    /// <param name="topic">The topic to subscribe to.</param>
    /// <param name="callback">The callback url.</param>
    /// <param name="verify">Either 'sync' or 'async'.</param>
    /// <param name="verifyToken">An optional token to be sent along with the verification.</param>
    /// <param name="leaseSeconds">The number of seconds the lease should be for.</param>
    /// <param name="woeIds">An array of WOE ids to listen to. Only applies if topic is 'geo'.</param>
    /// <param name="placeIds">
    /// An array of place ids to subscribe to. Only applies if topic is 'geo'.
    /// </param>
    /// <param name="latitude">The latitude to subscribe to. Only applies if topic is 'geo'.</param>
    /// <param name="longitude">The longitude to subscribe to. Only applies if topic is 'geo'.</param>
    /// <param name="radius">The radius to subscribe to. Only applies if topic is 'geo'.</param>
    /// <param name="radiusUnits">The raduis units to subscribe to. Only applies if topic is 'geo'.</param>
    /// <param name="accuracy">
    /// The accuracy of the geo search to subscribe to. Only applies if topic is 'geo'.
    /// </param>
    /// <param name="nsids">
    /// A list of Commons Institutes to subscribe to. Only applies if topic is 'commons'. If not
    /// present this argument defaults to all Flickr Commons institutions.
    /// </param>
    /// <param name="tags">
    /// A list of strings to be used for tag subscriptions. Photos with one or more of the tags
    /// listed will be included in the subscription. Only valid if the topic is 'tags'
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task PushSubscribeAsync(string topic, string callback, string verify, string verifyToken = null,
                                   int? leaseSeconds = null, IEnumerable<int> woeIds = null, IEnumerable<string> placeIds = null, double? latitude = null,
                                   double? longitude = null, int? radius = null, RadiusUnit radiusUnits = RadiusUnit.None, GeoAccuracy accuracy = GeoAccuracy.None,
                                   IEnumerable<string> nsids = null, IEnumerable<string> tags = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Unsubscribe from a particular push subscription.
    /// </summary>
    /// <param name="topic">The topic to unsubscribe from.</param>
    /// <param name="callback">The callback url to unsubscribe.</param>
    /// <param name="verify">Either 'sync' or 'async'.</param>
    /// <param name="verifyToken">
    /// The verification token to include in the unsubscribe verification process.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task PushUnsubscribeAsync(string topic, string callback, string verify, string verifyToken = null, CancellationToken cancellationToken = default);
}