namespace McKessonTest.API.Models
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public required string ExceptionMessage { get; set; }
        public required string Title {  get; set; }
    }
}
