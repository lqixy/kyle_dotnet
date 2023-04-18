using System.Net.Http.Headers;
using Kyle.ApiClients.Domain;
using Kyle.Extensions.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Kyle.ApiClients.Repositories;

public class HttpApiClient : IHttpApiClient
{
    private readonly IHttpClientFactory _factory;
    private readonly ILogger _logger;

    public HttpApiClient(IHttpClientFactory factory, ILogger<HttpApiClient> logger)
    {
        _factory = factory;
        _logger = logger;
    }

    public async Task<T> GetAsync<T>(string url, Dictionary<string, string> headers = null, int timeout = 180)
        where T : IApiResponse
    {
        var client = BuildHttpClient(headers, timeout);
        using var response = await client.GetAsync(url);
        var responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
            throw new UserFriendlyException(response.StatusCode.ToString(),
                $"报错url: {url}! Code:{response.StatusCode},报错类型: {response.ReasonPhrase}");

        _logger.LogInformation($"请求url: {url}; 返回: {responseContent}");
        return JsonConvert.DeserializeObject<T>(responseContent);
    }

    public async Task<TResult> PostAsync<TInput, TResult>(string url, TInput input,
        Dictionary<string, string> headers = null,
        int timeout = 180)
        where TResult : IApiResponse
        where TInput : IApiRequest
    {
        var client = BuildHttpClient(headers, timeout);
        using var response = await client.PostAsync(url, new JsonContent(input));
        var responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new UserFriendlyException(response.StatusCode.ToString(),
                $"报错url: {url}! Code:{response.StatusCode},报错类型: {response.ReasonPhrase}");
        }

        _logger.LogInformation($"请求url: {url}; 返回: {responseContent}");
        return JsonConvert.DeserializeObject<TResult>(responseContent);
    }

    private HttpClient BuildHttpClient(Dictionary<string, string> headers, int? timeout)
    {
        var httpClient = _factory.CreateClient();
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        if (headers != null && headers.Any())
        {
            foreach (var header in headers)
            {
                if (!httpClient.DefaultRequestHeaders.Contains(header.Key))
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
        }

        if (timeout.HasValue)
        {
            httpClient.Timeout = TimeSpan.FromSeconds(timeout.Value);
        }

        return httpClient;
    }
}