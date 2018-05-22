﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SteamStorefrontAPI
{
    public class Achievements
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("highlighted")]
        public List<Highlighted> Highlighted { get; set; }
    }
}