using retailpricechecker.Models;
using retailpricechecker.Services.Interfaces;
using System.Text.Json;

namespace retailpricechecker.Services
{
    public class CommercePricingClientService : ICommercePricingClientService
    {
        private readonly ILogger<CommercePricingClientService> _logger;
        private readonly HttpClient _httpClient;

        public CommercePricingClientService(ILogger<CommercePricingClientService> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<RetailPricingDto?> GetRetailPricingData(string upc, string locationId)
        {
            try
            {
                // https://api-dev.columbia.com/commercepricing/v1/commercepricing
                // e.g. GET https://api.columbia.com/commercepricing/v1/{upc + locationId}
                var finalUrl = $"{upc + locationId}";
                var responseResult = await _httpClient.GetAsync(finalUrl);

                if (responseResult.IsSuccessStatusCode)
                {
                    var jsonContent = await responseResult.Content.ReadAsStringAsync();

                    _logger.LogInformation($"Successfully got RetailPricingDTO from Commerce Pricing Service V1 for UPC: {upc} and LocationId: {locationId}");
                    var retailPricingDto = JsonSerializer.Deserialize<RetailPricingDto>(jsonContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return retailPricingDto;
                }
                else
                {
                    _logger.LogWarning($"API call failed with status {responseResult.StatusCode} for  UPC: {upc} and LocationId: {locationId}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed getting RetailProductDTO from Retail Product Service V1 for  UPC: {upc} and LocationId: {locationId}");
                return null;
            }
        }



    }
}
