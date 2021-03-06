﻿using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// chain_api_properties
    /// libraries\api\include\golos\api\chain_api_properties.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ChainApiProperties
    {

        /// <summary>
        /// API name: account_creation_fee
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("account_creation_fee")]
        public Asset AccountCreationFee { get; set; }

        /// <summary>
        /// API name: maximum_block_size
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("maximum_block_size")]
        public uint MaximumBlockSize { get; set; }

        /// <summary>
        /// API name: sbd_interest_rate
        /// 
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("sbd_interest_rate")]
        public ushort SbdInterestRate { get; set; }

        /// <summary>
        /// API name: create_account_min_golos_fee
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("create_account_min_golos_fee", NullValueHandling = NullValueHandling.Ignore)]
        public Asset CreateAccountMinGolosFee { get; set; }

        /// <summary>
        /// API name: create_account_min_delegation
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("create_account_min_delegation", NullValueHandling = NullValueHandling.Ignore)]
        public Asset CreateAccountMinDelegation { get; set; }

        /// <summary>
        /// API name: create_account_delegation_time
        /// 
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("create_account_delegation_time", NullValueHandling = NullValueHandling.Ignore)]
        public uint CreateAccountDelegationTime { get; set; }

        /// <summary>
        /// API name: min_delegation
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("min_delegation", NullValueHandling = NullValueHandling.Ignore)]
        public Asset MinDelegation { get; set; }
    }
}
