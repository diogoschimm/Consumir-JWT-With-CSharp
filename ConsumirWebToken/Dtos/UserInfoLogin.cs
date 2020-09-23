using Newtonsoft.Json;

namespace ConsumirWebToken.Dtos
{
    public class UserInfoLogin
    {
        public UserInfoLogin(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        [JsonProperty("username")]
        public string UserName { get; private set; }

        [JsonProperty("password")]
        public string Password { get; private set; }
    }
}
