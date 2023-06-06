namespace FlickrNet.Core.Configuration;

public class FlickrConfiguration
{
    public string ApiKey { get; set; }
    public string SharedSecret { get; set; }
    public bool CacheDisabled { get; set; }
    public string CacheLocation { get; set; }
    public int CacheSize { get; set; } = 0;
    public TimeSpan CacheTimeout { get; set; } = TimeSpan.MinValue;
}