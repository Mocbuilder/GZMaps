using Microsoft.AspNetCore.Mvc;

namespace GZMaps.wwwroot
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveJson([FromBody] object jsonData)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Saves");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, "data.json");

            string jsonString = JsonSerializer.Serialize(jsonData, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            System.IO.File.WriteAllText(filePath, jsonString);

            return Content("File saved successfully");
        }
    }
}
