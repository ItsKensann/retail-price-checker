using retailpricechecker.Services.Interfaces;

namespace retailpricechecker.Services
{
    public class ImageService : IImageService
    {
        private readonly ILogger<ImageService> _logger;
        private readonly HttpClient _httpClient;

        public ImageService(ILogger<ImageService> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<string?> GetProductImageString(string materialNumber)
        {
            try
            {
                // e.g. GET https://api.columbia.com/ContentHubImage/api/Image/v2/images/{materialNumber}
                var finalUrl = $"{materialNumber}";
                var responseResult = await _httpClient.GetAsync(finalUrl);

                if (responseResult.IsSuccessStatusCode)
                {
                    var imageString = await responseResult.Content.ReadAsStringAsync();
                    

                    _logger.LogInformation($"Successfully got RetailPricingDTO from Commerce Pricing Service V1 for MaterialNumber: {materialNumber}");

                    return imageString;
                }
                else
                {
                    _logger.LogWarning($"API call failed with status {responseResult.StatusCode} for  MaterialNumber: {materialNumber}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed getting RetailProductDTO from Retail Product Service V1 for MaterialNumber: {materialNumber}");
                return null;
            }
        }
    }
}
