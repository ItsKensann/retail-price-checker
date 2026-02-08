using Csc.Enterprise.Location.Dto;

namespace retailpricechecker.Services.Interfaces
{
    public interface ILocationClientService
    {
        Task<LocationDto?> GetLocationData(string storeID, string region);
    }
}
