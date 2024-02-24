using McKessonTest.API.Data;
using McKessonTest.API.Services.Interface;

namespace McKessonTest.API.Services
{
    public class LocationService : ILocationService
    {
        public readonly List<Location> locations;
        public LocationService()
        {
            locations = new List<Location>
            {
                new Location { LocationId = 1, LocationName = "Location 1", AvailabilityFrom = DateTime.Today.AddHours(10), AvailabilityTo = DateTime.Today.AddHours(12) },
                new Location { LocationId = 2, LocationName = "Location 2", AvailabilityFrom = DateTime.Today.AddHours(11), AvailabilityTo = DateTime.Today.AddHours(13) },
                // Add more locations as needed
            };
        }

        public async Task<List<Location>> GetLocationsAsync()
        {
            await Task.Delay(1000);
            return locations;
        }
    }
}
