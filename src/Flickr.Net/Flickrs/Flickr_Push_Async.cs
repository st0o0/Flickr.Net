using Flickr.Net.Entities;
using Flickr.Net.Enums;
using Flickr.Net.Internals.Extensions;

namespace Flickr.Net;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrPush
{
    async Task<Subscriptions> IFlickrPush.GetSubscriptionsAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.push.getSubscriptions" }
        };

        return await GetResponseAsync<Subscriptions>(parameters, cancellationToken);
    }

    async Task<TopicNames> IFlickrPush.GetTopicsAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.push.getTopics" }
        };

        return await GetResponseAsync<TopicNames>(parameters, cancellationToken);
    }

    async Task IFlickrPush.SubscribeAsync(string topic, string callback, string verify, string verifyToken,
                                  int? leaseSeconds, IEnumerable<WoeId> woeIds, IEnumerable<PlaceId> placeIds, double? latitude,
                                  double? longitude, int? radius, RadiusUnit radiusUnits, GeoAccuracy accuracy,
                                  IEnumerable<string> nsids, IEnumerable<string> tags, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        ArgumentException.ThrowIfNullOrEmpty(topic);

        ArgumentException.ThrowIfNullOrEmpty(callback);

        ArgumentException.ThrowIfNullOrEmpty(verify);

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

        parameters.AppendIf("verify_token", verifyToken, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("lease_seconds", leaseSeconds, x => x != null && leaseSeconds > 0, x => x.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("woe_ids", woeIds, x => x != null && x.Any(), x => string.Join(",", x));

        parameters.AppendIf("place_ids", placeIds, x => x != null && x.Any(), x => string.Join(",", x));

        parameters.AppendIf("lat", latitude, x => x.HasValue && x > 0 && topic == "geo", x => x.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("lon", longitude, x => x.HasValue && x > 0 && topic == "geo", x => x.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("radius", radius, x => x.HasValue && x > 0 && topic == "geo", x => x.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("radius_units", radiusUnits, x => x != RadiusUnit.None, x => radiusUnits.ToString("d"));

        parameters.AppendIf("accuracy", accuracy, x => x != GeoAccuracy.None, x => ((int)x).ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("nsids", nsids, x => x != null && x.Any() && topic == "commons", x => string.Join(",", x.ToArray()));

        parameters.AppendIf("tags", tags, x => x != null && x.Any() && topic == "tags", x => string.Join(",", x.ToArray()));

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task IFlickrPush.UnsubscribeAsync(string topic, string callback, string verify, string verifyToken, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        ArgumentException.ThrowIfNullOrEmpty(topic);

        ArgumentException.ThrowIfNullOrEmpty(callback);

        ArgumentException.ThrowIfNullOrEmpty(verify);

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.push.unsubscribe" },
            { "topic", topic },
            { "callback", callback },
            { "verify", verify }
        };

        parameters.AppendIf("verify_token", verifyToken, x => !string.IsNullOrEmpty(x), x => x);

        await GetResponseAsync(parameters, cancellationToken);
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
    Task<Subscriptions> GetSubscriptionsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of topics that are available for subscription.
    /// </summary>
    /// <param name="cancellationToken"></param>
    Task<TopicNames> GetTopicsAsync(CancellationToken cancellationToken = default);

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
    Task SubscribeAsync(string topic, string callback, string verify, string verifyToken = null,
                                   int? leaseSeconds = null, IEnumerable<WoeId> woeIds = null, IEnumerable<PlaceId> placeIds = null, double? latitude = null,
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
    Task UnsubscribeAsync(string topic, string callback, string verify, string verifyToken = null, CancellationToken cancellationToken = default);
}