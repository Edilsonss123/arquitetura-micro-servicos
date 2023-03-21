using System.Text.Json;

namespace GeekShopping.Web.Utils
{
    public static class HttpClienteExtensions
    {
        public static async Task<T> ReadContextAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode) 
            {
                Console.WriteLine(response);
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            }

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return  JsonSerializer.Deserialize<T>(
                dataAsString, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }

    }
}