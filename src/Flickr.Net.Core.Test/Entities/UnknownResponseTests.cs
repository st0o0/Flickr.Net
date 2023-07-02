using Flickr.Net.Core.Enums;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class UnknownResponseTests
{
    [Fact]
    public void JsonStringToCommentUnknownResponse()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "comment": {
                "id": "97777-72057594037941949-72057594037942602"
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrUnknownResult<CommentUnknownResponse>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<CommentUnknownResponse>(items);
        Assert.True(items.ContainsKey("id"));
    }

    [Fact]
    public void JsonStringToNoteUnknownResponse()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "note": {
                "id": "1234"
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrUnknownResult<NoteUnknownResponse>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<NoteUnknownResponse>(items);
        Assert.True(items.ContainsKey("id"));
        Assert.Equal("1234", items.GetValueOrDefault("id"));
    }

    [Fact]
    public void JsonStringToPhotosetUnknownResponse()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "photoset": {
                "id": "1234",
                "url": "http://www.flickr.com/photos/bees/sets/1234/"
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrUnknownResult<PhotosetUnknownResponse>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<PhotosetUnknownResponse>(items);
        Assert.True(items.ContainsKey("id"));
        Assert.Equal("1234", items.GetValueOrDefault("id"));
        Assert.Equal("http://www.flickr.com/photos/bees/sets/1234/", items.GetValueOrDefault("url"));
    }

    [Fact]
    public void JsonStringToPersonUnknownResponse()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "person": {
                "nsid": "12037949754@N01",
                "content_type": "1"
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrUnknownResult<PersonUnknownResponse>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<PersonUnknownResponse>(items);
        Assert.True(items.ContainsKey("nsid"));
        Assert.Equal("12037949754@N01", items.GetValueOrDefault("nsid"));
        Assert.Equal(ContentType.Photo, (ContentType)int.Parse(items.GetValueOrDefault("content_type", string.Empty), System.Globalization.NumberFormatInfo.InvariantInfo));
    }

    [Fact]
    public void JsonStringToGroupUnknownResponse()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "group": {
                "nsid": "48508120860@N01",
                "url": "http://www.flickr.com/groups/test1/"
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrUnknownResult<GroupUnknownResponse>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<GroupUnknownResponse>(items);
        Assert.True(items.ContainsKey("nsid"));
        Assert.Equal("48508120860@N01", items.GetValueOrDefault("nsid"));
    }

    [Fact]
    public void JsonStringToUserUnknownResponse()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "user": {
                "id": "12037949632@N01",
                "username": "Stewart"
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrUnknownResult<UserUnknownResponse>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<UserUnknownResponse>(items);
        Assert.True(items.ContainsKey("id"));
        Assert.Equal("12037949632@N01", items.GetValueOrDefault("id"));
    }
}
