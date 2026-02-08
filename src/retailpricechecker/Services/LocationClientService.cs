using Csc.Enterprise.Location.Dto;
using System.Text.Json;
using retailpricechecker.Services.Interfaces;

namespace retailpricechecker.Services
{
    public class LocationClientService : ILocationClientService
    {
        private readonly ILogger<LocationClientService> _logger;
        private readonly HttpClient _httpClient;

        public LocationClientService(ILogger<LocationClientService> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<LocationDto?> GetLocationData(string storeId, string region)
        {
            try
            {
                // e.g.GET https://api.columbia.com/locations/v1/locations/{id}
                // id is the concatenation of store number and region (e.g. 401US)
                var finalUrl = _httpClient.BaseAddress + storeId + region;
                var responseResult = await _httpClient.GetAsync(finalUrl);

                if (responseResult.IsSuccessStatusCode)
                {
                    var jsonContent = await responseResult.Content.ReadAsStringAsync();

                    _logger.LogInformation($"Successfully getting LocationDTO payload from Ent. Location Service V1 for StoreId: {storeId} and Region {region}");
                    var locationDto = JsonSerializer.Deserialize<LocationDto>(jsonContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return locationDto;
                }
                else
                {
                    _logger.LogWarning($"API call failed with status {responseResult.StatusCode} for StoreId: {storeId} and Region {region}");
                    return null;
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, ex.Message);
                _logger.LogInformation($"Failed getting LocationDTO from Ent. Location Service V1 for StoreId: {storeId} and Region {region}");

                return null!;
            }
        }
    }
}