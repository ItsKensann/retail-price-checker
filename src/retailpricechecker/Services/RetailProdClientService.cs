using Csc.D365.RetailProduct.Dto;
using System.Text.Json;
using retailpricechecker.Services.Interfaces;

namespace retailpricechecker.Services
{
    public class RetailProdClientService : IRetailProdClientService
    {
        private readonly ILogger<RetailProdClientService> _logger;
        private readonly HttpClient _httpClient;

        public RetailProdClientService(ILogger<RetailProdClientService> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<RetailProductDTO?> GetRetailProductData(string region, string materialStyleNumber)
        {
            try
            {
                // e.g. GET https://api.columbia.com/retail-product-api/v1/retailmasters/{region}/{materialStyleNumber}
                // e.g. region = USA and materialStyleNumber = 2063661
                var finalUrl = $"{region}/{materialStyleNumber}";
                var responseResult = await _httpClient.GetAsync(finalUrl);

                if (responseResult.IsSuccessStatusCode)
                {
                    var jsonContent = await responseResult.Content.ReadAsStringAsync();

                    _logger.LogInformation($"Successfully got RetailProductDTO from Retail Product Service V1 for Region: {region} and MaterialStyleNumber: {materialStyleNumber}");
                    var retailProductDto = JsonSerializer.Deserialize<RetailProductDTO>(jsonContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return retailProductDto;
                }
                else
                {
                    _logger.LogWarning($"API call failed with status {responseResult.StatusCode} for Region: {region} and MaterialStyleNumber: {materialStyleNumber}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed getting RetailProductDTO from Retail Product Service V1 for Region: {region} and MaterialStyleNumber: {materialStyleNumber}");
                return null;
            }
        }
    }
}