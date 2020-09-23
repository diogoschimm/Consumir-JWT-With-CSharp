using Newtonsoft.Json;

namespace ConsumirWebToken.Dtos
{
    public class TokenInfo
    {
        public bool Success { get; set; }
        public string Message { get; set; }


        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
