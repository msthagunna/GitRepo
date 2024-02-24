using System.Text.Json.Serialization;

namespace McKessonTest.API.Models
{
    public class LocationModel
    {        
        [JsonPropertyName("id")]
        public int? LocationId { get; set; }

        [JsonPropertyName("location")]
        public string? LocationName { get; set; }

        [JsonPropertyName("from")]
        public DateTime AvailabilityFrom { get; set; }

        [JsonPropertyName("to")]
        public DateTime AvailabilityTo { get; set; }
    }
}
