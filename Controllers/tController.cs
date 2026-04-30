using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection;

namespace GZMaps.Controllers
{
    public class tController : Controller
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

            string jsonString = System.Text.Json.JsonSerializer.Serialize(jsonData, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            });

            System.IO.File.WriteAllText(Path.Combine(_mapDataFolder, "data.json"), jsonString);

            return Content("File saved successfully");
        }

        [HttpGet]
        public IActionResult GETMapData()
        {
            string filePath = Path.Combine(
                _mapDataFolder,
                "data.json"
            );

            string jsonData = System.IO.File.ReadAllText(filePath);
            var obj = System.Text.Json.JsonSerializer.Deserialize<object>(jsonData);

            return Json(obj);
        }

        [HttpGet]
        public IActionResult GETPassword()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = "GZMaps.password.json";

            using Stream stream = assembly.GetManifestResourceStream(resourceName) ?? throw new FileNotFoundException("Embedded JSON file not found.", resourceName);

            if (stream == null)
            {
                return NotFound("Embedded JSON file not found.");
            }

            using StreamReader reader = new StreamReader(stream);
            string jsonData = reader.ReadToEnd();

            var obj = System.Text.Json.JsonSerializer.Deserialize<object>(jsonData);

            return Json(obj);
        }
    }
}
