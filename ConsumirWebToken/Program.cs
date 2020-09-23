using ConsumirWebToken.Dtos;
using ConsumirWebToken.Services;
using System;

namespace ConsumirWebToken
{
    class Program
    {
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
    }
}
