using McKessonTest.API.Data;

namespace McKessonTest.API.Services.Interface
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocationsAsync();
    }
}
