using Csc.D365.RetailProduct.Dto;

namespace retailpricechecker.Services.Interfaces
{
    public interface IRetailProdClientService
    {
        Task<RetailProductDTO?> GetRetailProductData(string region, string materialStyleNumber);
    }
}