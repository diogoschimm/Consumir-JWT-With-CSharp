using ConsumirWebToken.Dtos;
using ConsumirWebToken.Utils;
using Newtonsoft.Json;

namespace ConsumirWebToken.Services
{
    public class TokenService
    {
        private readonly string _urlToken;

        public TokenService(string urlToken)
        {
            this._urlToken = urlToken;
        }

        public TokenInfo GetToken(UserInfoLogin userInfo)
        { 
            var jsonEnvio = JsonConvert.SerializeObject(userInfo);
            var jsonRetorno = Request.Post(_urlToken, jsonEnvio);

            var tokenInfo = JsonConvert.DeserializeObject<TokenInfo>(jsonRetorno);
            if (tokenInfo != null && !string.IsNullOrEmpty(tokenInfo.Token))
            {
                tokenInfo.Success = true;
                tokenInfo.Message = "Token obtido com sucesso";
            }

            return tokenInfo ;
        }
    }
}
