# Consumir-JWT-With-CSharp
Consumir JWT com CSharp

## Arquivo Main

```c#
    static void Main(string[] args)
    {
        var url = "https://igti-film.herokuapp.com/api/SignIn";
        var userName = "MeuUsuario";
        var password = "MinhaSenha";

        var tokenService = new TokenService(url);
        var tokenInfo = tokenService.GetToken(new UserInfoLogin(userName, password));

        if (tokenInfo.Success)
            Console.WriteLine($"{tokenInfo.Message}, Token={tokenInfo.Token}");
        else
            Console.WriteLine(tokenInfo.Message);

        Console.ReadKey();
    }
```


## TokenService (Serviço de obtenção do Token)

```csharp
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
```

## DTOS (Para User e Token)

```csharp
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

  public class TokenInfo
  {
      public bool Success { get; set; }
      public string Message { get; set; }


      [JsonProperty("token")]
      public string Token { get; set; }
  }
```

## Classe de Utilitário para Fazer o POST

```c#
  public class Request
  {
      public static string Post(string url, string dados)
      {
          string strRetorno;
          try
          {
              byte[] byteArray = Encoding.ASCII.GetBytes(dados);

              var request = WebRequest.Create(url);
              request.Method = "POST";
              request.ContentType = "application/json";
              request.ContentLength = byteArray.Length;

              var dataStream = request.GetRequestStream();
              dataStream.Write(byteArray, 0, byteArray.Length);

              var response = request.GetResponse();
              strRetorno = new StreamReader(response.GetResponseStream()).ReadToEnd(); 
          }
          catch (Exception ex)
          {
              strRetorno = $@"{{ ""success"": false, ""message"": ""{ex.Message.Replace("'", "")}"" }}";
          }
          return strRetorno;
      }
  }
```
