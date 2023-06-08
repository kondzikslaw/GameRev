using RestSharp;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace GameRev.ApplicationServices.Components.GiantBomb
{
    public class GiantBombConnector : IGiantBombConnector
    {
        private readonly RestClient _restClient;
        private readonly string _baseUrl = "https://www.giantbomb.com/api/";
        private readonly ApiConfig _apiConfig;
        private readonly ILogger<GiantBombConnector> _logger;

        public GiantBombConnector(IOptions<ApiConfig> apiConfig, ILogger<GiantBombConnector> logger)
        {
            _restClient = new RestClient(_baseUrl);
            _apiConfig = apiConfig.Value;
            _logger = logger;
        }

        public async Task<Game> Fetch(string guid)
        {
            _logger.LogInformation("Trying to get data from GiantBomb API.");
            //var request = new RestRequest($"{_baseUrl}/game/{guid}/?api_key={_apiKey}&format=json", Method.Get);
            var request = new RestRequest($"game/{guid}/", Method.Get);
            request.AddParameter("api_key", _apiConfig.ApiKey);
            request.AddParameter("format", "json");
            //request.AddParameter("field_list", "guid,name,description,expected_release_year");
            var queryResult = await _restClient.ExecuteAsync(request);
            var game = JsonConvert.DeserializeObject<Game>(queryResult.Content);
            if (game != null)
            {
                _logger.LogInformation(queryResult.Content);
                _logger.LogInformation("Getting data finished with success");
            }
            else
            {
                _logger.LogWarning("There is no matching data.");
            }
            return game;
        }
    }
}
