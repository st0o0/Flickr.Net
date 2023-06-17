using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities.Collections;

public abstract class FlickrCollection<T>
{
    [JsonPropertyGenericTypeName(0)]
    public List<T> Values { get; set; }

    public static implicit operator List<T>(FlickrCollection<T> collection) => collection.Values;
}

[FlickrJsonPropertyName("blogs")]
public class Blogs : FlickrCollection<Blog>
{ }

[FlickrJsonPropertyName("items")]
public class Items : FlickrCollection<Item>
{ }

[FlickrJsonPropertyName("services")]
public class Services : FlickrCollection<Service>
{ }

[FlickrJsonPropertyName("cameras")]
public class Cameras : FlickrCollection<Camera>
{
    [JsonProperty("brand")]
    public string Brand { get; set; }
}

[FlickrJsonPropertyName("brands")]
public class Brands : FlickrCollection<Brand>
{ }

[FlickrJsonPropertyName("photo")]
public class Photos : FlickrCollection<Photo>
{ }