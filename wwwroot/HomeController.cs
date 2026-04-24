using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection;

namespace GZMaps.wwwroot
{
    public class HomeController : Controller
    {
        string _mapDataFolder = Path.Combine(Directory.GetCurrentDirectory(), "MapData");

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult POSTMapData([FromBody] object jsonData)
        {
            if (!Directory.Exists(_mapDataFolder))
            {
                Directory.CreateDirectory(_mapDataFolder);
            }

            string jsonString = JsonSerializer.Serialize(jsonData, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(Path.Combine(_mapDataFolder, "data.json");, jsonString);

            return Content("File saved successfully");
        }

        [HttpGet]
        public IActionResult GetMapData()
        {
            string filePath = Path.Combine(
                _mapDataFolder,
                "data.json"
            );

            string jsonData = System.IO.File.ReadAllText(filePath);
            var obj = JsonConvert.DeserializeObject(jsonData);

            return Json(obj);
        }

        [HttpGet]
        public IActionResult GetMapData()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = "GZMaps.password.json";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);

            if (stream == null)
            {
                return NotFound("Embedded JSON file not found.");
            }

            using StreamReader reader = new StreamReader(stream);
            string jsonData = reader.ReadToEnd();

            var obj = JsonConvert.DeserializeObject(jsonData);

            return Json(obj);
        }
    }
}
