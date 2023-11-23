namespace Flickr.Net.Internals.Extensions;

/// <summary>
/// </summary>
public static class SearchOptionsExtensions
{
    /// <summary>
    /// </summary>
    internal static IDictionary<string, string> ToDictionary(this PhotoSearchOptions options)
    {
        var parameters = new Dictionary<string, string>();

        parameters.AppendIf("user_id", options.UserId, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("group_id", options.GroupId, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("text", options.Text, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("tags", options.Tags, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("tag_mode", options.TagMode, x => x != TagMode.None, x => x.GetEnumMemberValue());

        parameters.AppendIf("machine_tags", options.MachineTags, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("machine_tag_mode", options.MachineTagMode, x => x != MachineTagMode.None, x => x.GetEnumMemberValue());

        parameters.AppendIf("min_upload_date", options.MinUploadDate, x => x != DateTime.MinValue, x => x.ToUnixTimestamp());

        parameters.AppendIf("max_upload_date", options.MaxUploadDate, x => x != DateTime.MinValue, x => x.ToUnixTimestamp());

        parameters.AppendIf("min_taken_date", options.MinTakenDate, x => x != DateTime.MinValue, x => x.ToMySql());

        parameters.AppendIf("max_taken_date", options.MaxTakenDate, x => x != DateTime.MinValue, x => x.ToMySql());

        parameters.AppendIf("license", options.Licenses, x => x.Count != 0, x => string.Join(",", x.Distinct().Select(item => item.GetEnumMemberValue())));

        parameters.AppendIf("per_page", options.PerPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", options.Page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("extras", options.Extras, x => x != PhotoSearchExtras.None, x => x.ToFlickrString());

        parameters.AppendIf("sort", options.SortOrder, x => x != PhotoSearchSortOrder.None, x => x.ToFlickrString());

        parameters.AppendIf("privacy_filter", options.PrivacyFilter, x => x != PrivacyFilter.None, x => x.ToString("d"));

        parameters.AppendIf("bbox", options.BoundaryBox, x => x != null && x.IsSet, x => x.ToString());

        parameters.AppendIf("accuracy", options.BoundaryBox, x => x != null && x.IsSet && x.Accuracy != GeoAccuracy.None, x => x.Accuracy.ToString("d"));

        parameters.AppendIf("safe_search", options.SafeSearch, x => x != SafetyLevel.None, x => x.ToString("d"));

        parameters.AppendIf("content_type", options.ContentType, x => x != ContentTypeSearch.None, x => x.ToString("d"));

        parameters.AppendIf("has_geo", options.HasGeo, x => x != null, x => x.Value ? "1" : "0");

        parameters.AppendIf("lat", options.Latitude, x => x != null, x => x.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("lon", options.Longitude, x => x != null, x => x.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("radius", options.Radius, x => x != null, x => x.Value.ToString("0.00000", System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("radius_units", options.RadiusUnits, x => x != RadiusUnit.None, x => x.GetEnumMemberValue());

        parameters.AppendIf("contacts", options.Contacts, x => x != ContactSearch.None, x => x.GetEnumMemberValue());

        parameters.AppendIf("woe_id", options.WoeId, x => x != null, x => x);

        parameters.AppendIf("place_id", options.PlaceId, x => x != null, x => x);

        parameters.AppendIf("is_commons", options.IsCommons, x => x, x => "1");

        parameters.AppendIf("in_gallery", options.InGallery, x => x, x => "1");

        parameters.AppendIf("is_getty", options.IsGetty, x => x, x => "1");

        parameters.AppendIf("media", options.MediaType, x => x != MediaType.None, x => x.GetEnumMemberValue());

        parameters.AppendIf("geo_context", options.GeoContext, x => x != GeoContext.NotDefined, x => x.GetEnumMemberValue());

        parameters.AppendIf("faves", options.Faves, x => x, x => "1");

        parameters.AppendIf("person_id", options.PersonId, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("camera", options.Camera, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("jump_to", options.JumpTo, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("username", options.Username, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("exif_min_exposure", options.ExifMinExposure, x => x != null, x => x.Value.ToString("0.00000", System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("exif_max_exposure", options.ExifMaxExposure, x => x != null, x => x.Value.ToString("0.00000", System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("exif_min_aperture", options.ExifMinAperture, x => x != null, x => x.Value.ToString("0.00000", System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("exif_max_aperture", options.ExifMaxAperture, x => x != null, x => x.Value.ToString("0.00000", System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("exif_min_focallen", options.ExifMinFocalLength, x => x != null, x => x.Value.ToString("0", System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("exif_max_focallen", options.ExifMaxFocalLength, x => x != null, x => x.Value.ToString("0", System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("exclude_user_id", options.ExcludeUserID, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("foursquare_venueid", options.FoursquareVenueID, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("foursquare_woeid", options.FoursquareWoeID, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("group_path_alias", options.GroupPathAlias, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("color_codes", options.ColorCodes, x => x != null && x.Count != 0, x => x.ToFlickrString());

        parameters.AppendIf("styles", options.Styles, x => x != null && x.Count != 0, x => x.ToFlickrString());

        return parameters;
    }

    /// <summary>
    /// </summary>
    internal static IDictionary<string, string> ToDictionary(this PartialSearchOptions options)
    {
        var parameters = new Dictionary<string, string>();

        parameters.AppendIf("min_uploaded_date", options.MinUploadDate, x => x != DateTime.MinValue, x => x.ToUnixTimestamp());

        parameters.AppendIf("max_uploaded_date", options.MaxUploadDate, x => x != DateTime.MinValue, x => x.ToUnixTimestamp());

        parameters.AppendIf("min_taken_date", options.MinTakenDate, x => x != DateTime.MinValue, x => x.ToMySql());

        parameters.AppendIf("max_taken_date", options.MaxTakenDate, x => x != DateTime.MinValue, x => x.ToMySql());

        parameters.AppendIf("extras", options.Extras, x => x != PhotoSearchExtras.None, x => x.ToFlickrString());

        parameters.AppendIf("sort", options.SortOrder, x => x != PhotoSearchSortOrder.None, x => x.ToFlickrString());

        parameters.AppendIf("per_page", options.PerPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", options.Page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("privacy_filter", options.PrivacyFilter, x => x != PrivacyFilter.None, x => x.ToString("d"));

        return parameters;
    }
}
