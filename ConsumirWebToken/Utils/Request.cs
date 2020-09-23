using System;
using System.IO;
using System.Net;
using System.Text;

namespace ConsumirWebToken.Utils
{
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
}
