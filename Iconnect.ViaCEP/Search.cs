using IConnect.ViaCEP.Exceptions;
using IConnect.ViaCEP.Model;
using IConnect.ViaCEP.Services;
using IConnect.ViaCEP.Types;
using Newtonsoft.Json;
using System;

namespace IConnect.ViaCEP
{
    public class Search
    {
        /// <summary>
        /// Search address by Zip Code
        /// </summary>
        /// <param name="zipCode">Zip code value</param>
        /// <param name="type">The type to search address. Use ViaCEPTypes object to help. Possible values include: 'json', 'xml', 'piped' and 'querty'</param>
        /// <returns>String with result in type selected</returns>
        /// 
        public static string ByZipCode(string zipCode, string type)
        {
            try
            {
                var result = ViaCEPServices.GetAddressByCEP(zipCode, type);

                return result;
            }
            catch (CEPLibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CEPLibraryException(ex.Message);
            }
        }

        /// <summary>
        /// Search address by Zip Code
        /// </summary>
        /// <param name="zipCode">Zip code value</param>
        /// <returns>Object with address result</returns>
        public static ViaCEPModel ByZipCode(string zipCode)
        {
            try
            {
                var jsonResult = ViaCEPServices.GetAddressByCEP(zipCode, ViaCEPTypes.Json);

                var objectResult = JsonConvert.DeserializeObject<ViaCEPModel>(jsonResult);

                return objectResult;
            }
            catch (CEPLibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CEPLibraryException(ex.Message);
            }
        }
    }
}
