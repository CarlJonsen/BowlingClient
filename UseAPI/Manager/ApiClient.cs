using BowlingClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BowlingClient.Manager
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient();
        }

        // Generisk metod för POST-anrop
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUrl, TRequest data)
            where TResponse : ErrorResponeDto, new()
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(requestUrl, data);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<TResponse>(responseBody);
                    return result ?? new TResponse();
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<ErrorResponeDto>(responseBody);
                    return new TResponse { Message = error?.Message ?? "Ett okänt fel uppstod." };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid API-anrop: {ex.Message}");
                return new TResponse { Message = "Ett fel uppstod vid anslutning till servern." };
            }
        }



        // Generisk metod för GET-anrop
        public async Task<List<T>> GetAsync<T>(string requestUrl)
        {
            try
            {
                var response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<T>>(responseBody);
                    return result ?? new List<T>();
                }
                else
                {
                    Console.WriteLine($"Fel vid hämtning av data: {response.ReasonPhrase}");
                    return new List<T>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid API-anrop: {ex.Message}");
                return new List<T>();
            }
        }
    }
}
