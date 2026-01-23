using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ApiService : IDisposable
    {
        private readonly HttpClient _httpClient;

        // Constructor to initialize HttpClient
        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        // Asynchronous method to fetch data from API
        public async Task<string> FetchDataAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"Error: {response.StatusCode}";
            }
        }
        public async Task<HttpResponseMessage> PostDataAsync(string url, object data, string token, JsonSerializerOptions options = null, int maxRetries = 3, int delaySeconds = 2, bool requireJsonAccept = false)
        {
            string json = JsonSerializer.Serialize(data, options); // Convert object to JSON string
                                                                   // var content = new StringContent(json, Encoding.UTF8, "application/json");
                                                                   //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    using var content = new StringContent(json, Encoding.UTF8, "application/json");
                    using var request = new HttpRequestMessage(HttpMethod.Post, url)
                    {
                        Content = content
                    };
                    if (!string.IsNullOrWhiteSpace(token))
                        request.Headers.Authorization =
                            new AuthenticationHeaderValue("Bearer", token);
                    if (requireJsonAccept)
                    {
                        request.Headers.Accept.Clear();
                        request.Headers.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                    }

                    var response = await _httpClient.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                        return response;
                }
                catch (Exception ex) when (attempt < maxRetries)
                {
                    // Optional: Log the exception but how?
                    await Task.Delay(TimeSpan.FromSeconds(delaySeconds));
                    Console.WriteLine(ex.ToString());
                }
            }

            using var finalContent = new StringContent(json, Encoding.UTF8, "application/json");
            using var finalRequest = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = finalContent
            };

            if (!string.IsNullOrWhiteSpace(token))
                finalRequest.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            if (requireJsonAccept)
            {
                finalRequest.Headers.Accept.Clear();
                finalRequest.Headers.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }

            return await _httpClient.SendAsync(finalRequest);
        }
        //public async Task<HttpResponseMessage> PostSMSAsync(string url, object data, JsonSerializerOptions options = null, int maxRetries = 3, int delaySeconds = 2)
        //{

        //    string json = JsonSerializer.Serialize(data, options); // Convert object to JSON string
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    _httpClient.DefaultRequestHeaders.Accept.Clear();
        //        _httpClient.DefaultRequestHeaders.Accept.Add(
        //            new MediaTypeWithQualityHeaderValue("application/json"));


        //    for (int attempt = 1; attempt <= maxRetries; attempt++)
        //    {
        //        try
        //        {
        //            var response = await _httpClient.PostAsync(url, content);
        //            var error = await response.Content.ReadAsStringAsync();

        //            if (response.IsSuccessStatusCode)
        //                return response;
        //        }
        //        catch (Exception ex) when (attempt < maxRetries)
        //        {
        //            // Optional: Log the exception but how?
        //            await Task.Delay(TimeSpan.FromSeconds(delaySeconds));
        //        }
        //    }

        //    return await _httpClient.PostAsync(url, content);
        //}
        //public async Task<HttpResponseMessage> PostWithRetryAsync(string url, HttpContent content, int maxRetries = 3, int delaySeconds = 2)
        //{
        //    for (int attempt = 1; attempt <= maxRetries; attempt++)
        //    {
        //        try
        //        {
        //            var response = await _httpClient.PostAsync(url, content);
        //            if (response.IsSuccessStatusCode)
        //                return response;

        //            // Optional: Log non-success status here
        //        }
        //        catch (Exception ex) when (attempt < maxRetries)
        //        {
        //            // Optional: Log the exception
        //            await Task.Delay(TimeSpan.FromSeconds(delaySeconds));
        //        }
        //    }

        //    // Final attempt, no try/catch to bubble up the error
        //    return await _httpClient.PostAsync(url, content);
        //}
        string GetInnermostExceptionMessage(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex.Message;
        }

    }
}
