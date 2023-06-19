using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flickr.Net.Core.Enums;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Throttle
{
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("mode")]
    public ThrottleMode Mode { get; set; }

    [JsonProperty("remaining")]
    public int Remaining { get; set; }
}
