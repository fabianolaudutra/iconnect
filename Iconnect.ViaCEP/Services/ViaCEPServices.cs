using IConnect.ViaCEP.Exceptions;
using System;
using System.Net.Http;

namespace IConnect.ViaCEP.Services
{
    public class ViaCEPServices
    {
        public static string GetAddressByCEP(string cep, string type)
        {
            try
            {
                string result = string.Empty;

                string viaCEPUrl = $"https://viacep.com.br/ws/{cep}/{type}/";

                HttpClient client = new HttpClient();
                result = client.GetAsync(viaCEPUrl).ToString();

                return result;
            }
            catch (Exception ex)
            {
                throw new CEPLibraryException(ex.Message);
            }
        }
    }
}
