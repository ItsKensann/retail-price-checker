using retailpricechecker.Models;

namespace retailpricechecker.Services.Interfaces
{
    public interface ICommercePricingClientService
    {
        Task<RetailPricingDto?> GetRetailPricingData(string upc, string locationId);
    }
}
