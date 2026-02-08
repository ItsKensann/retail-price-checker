using Csc.Enterprise.Location.Dto;

namespace retailpricechecker.Services
{
    public class LocationState
    {
        private LocationDto? _currentLocation;

        public event Action<LocationDto>? OnLocationChanged;

        public LocationDto? CurrentLocation => _currentLocation;

        public void SetLocation(LocationDto location)
        {
            _currentLocation = location;
            OnLocationChanged?.Invoke(location);
        }

    }
}
