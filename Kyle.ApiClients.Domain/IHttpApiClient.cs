namespace Kyle.ApiClients.Domain;

public interface IHttpApiClient
{
    Task<T> GetAsync<T>(string url, Dictionary<string, string> headers = null, int timeout = 180)
        where T : IApiResponse;

    Task<TResult> PostAsync<TInput, TResult>(string url, TInput input,
        Dictionary<string, string> headers = null,
        int timeout = 180)
        where TResult : IApiResponse
        where TInput : IApiRequest;
}