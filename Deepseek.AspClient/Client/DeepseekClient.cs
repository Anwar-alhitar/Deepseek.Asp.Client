using Deepseek.AspClient.Exceptions;
using Deepseek.AspClient.Models.Request;
using Deepseek.AspClient.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Deepseek.AspClient.Client
{
    public class DeepseekClient : IDeepseekClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public DeepseekClient(string apiKey, string baseUrl = "https://api.deepseek.com/v1/")
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<DeepseekResponse> GenerateResponseAsync(DeepseekRequest request)
        {
            try
            {
                var content = new StringContent(
                    JsonSerializer.Serialize(request, _jsonOptions),
                    Encoding.UTF8,
                    "application/json");

                var response = await _httpClient.PostAsync("chat/completions", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var error = JsonSerializer.Deserialize<ApiError>(responseContent, _jsonOptions);
                    throw new DeepseekException(
                        $"API Error: {error?.Message ?? "Unknown error"}",
                        response.StatusCode);
                }

                return JsonSerializer.Deserialize<DeepseekResponse>(responseContent, _jsonOptions);
            }
            catch (Exception ex)
            {
                throw new DeepseekException("Request failed", HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<DeepseekResponse> GenerateResponseAsync(string prompt)
        {
            return await GenerateResponseAsync(new DeepseekRequest
            {
                Messages = [new Message { Content = prompt }]
            });
        }
    }
}
