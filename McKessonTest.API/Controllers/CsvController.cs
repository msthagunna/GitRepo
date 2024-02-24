using System.Formats.Asn1;
using System.Globalization;
using System.Text;
using CsvHelper;
using McKessonTest.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McKessonTest.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CsvController : ControllerBase
    {
        private static string uploadsDirectory => Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        public CsvController()
        {
            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }
        }

        [HttpGet("download")]
        public IActionResult DownloadCsv()
        {
            // Sample CSV data (replace this with your actual data)
            var csvData = "Column1,Column2\nValue1,Value2\nValue3,Value4";

            // Set the content type and file name
            var contentType = "text/csv";
            var fileName = "example.csv";

            // Convert the CSV string to bytes
            var data = Encoding.UTF8.GetBytes(csvData);

            // Create a MemoryStream to store the CSV content
            var stream = new MemoryStream(data);

            // Return the CSV file as a FileStreamResult
            return File(stream, contentType, fileName);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadCsv([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file");
            }
            else
            {
                var fileName = $"{Guid.NewGuid()}_{file.FileName}";
                var filePath = Path.Combine(uploadsDirectory, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                    {
                        var records = await csvReader.GetRecordsAsync<dynamic>().ToListAsync();

                        // write code here to process or save the data.

                        return Ok(new { FilePath = filePath, Records = records });
                    }
                }
            }
        }
    }
}
