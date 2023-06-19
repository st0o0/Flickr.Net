using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Pair
{
    [JsonProperty("namespace")]
    public string Namespace { get; set; }

    [JsonProperty("predicate")]
    public string Predicate { get; set; }

    [JsonProperty("usage")]
    public string Usage { get; set; }

    [JsonProperty("_content")]
    public string Content { get; set; }
}
