﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Activity
{
    [JsonProperty("event")]
    public List<Event> Events { get; set; }
}
