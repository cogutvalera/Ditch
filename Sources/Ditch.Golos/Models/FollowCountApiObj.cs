using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// follow_count_api_obj
    /// plugins\follow\include\golos\plugins\follow\follow_api_object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FollowCountApiObj
    {

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("account")]
        public string Account {get; set;}

        /// <summary>
        /// API name: follower_count
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("follower_count")]
        public uint FollowerCount {get; set;}

        /// <summary>
        /// API name: following_count
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("following_count")]
        public uint FollowingCount {get; set;}

        /// <summary>
        /// API name: limit
        /// = 1000;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public uint Limit {get; set;}
    }
}
