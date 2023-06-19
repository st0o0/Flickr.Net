using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Member
{
    [JsonProperty("nsid")]
    public string Id { get; set; }

    [JsonProperty("username")]
    public string UserName { get; set; }

    [JsonProperty("iconserver")]
    public string IconServer { get; set; }

    [JsonProperty("iconfarm")]
    public string IconFarm { get; set; }

    [JsonProperty("membertype")]
    public MemberType Type { get; set; }

    /// <summary>
    /// The icon URL for the users buddy icon. Calculated from the <see cref="IconFarm"/> and <see cref="IconServer"/>.
    /// </summary>
    public string IconUrl => UtilityMethods.BuddyIcon(IconServer, IconFarm, Id);
}