namespace McKessonTest.API.Data
{
    public class Location
    {
        public int? LocationId { get; set; }

        public string? LocationName { get; set; }

        public DateTime AvailabilityFrom { get; set; }

        public DateTime AvailabilityTo { get; set; }
    }
}
