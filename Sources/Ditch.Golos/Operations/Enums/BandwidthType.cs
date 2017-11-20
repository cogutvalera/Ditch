﻿using Ditch.Core.Helpers;
using Newtonsoft.Json;

namespace Ditch.Golos.Operations.Enums
{
    [JsonConverter(typeof(EnumConverter))]
    public enum BandwidthType
    {
        /// <summary>
        /// Rate limiting posting reward eligibility over time
        /// </summary>
        Post,

        /// <summary>
        /// Rate limiting for all forum related actins
        /// </summary>
        Forum,

        /// <summary>
        /// Rate limiting for all other actions
        /// </summary>
        Market
    }
}