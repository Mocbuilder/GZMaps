using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection;
using GZMaps.Models;
using System.Text.Json;

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

        [HttpPost]
        public IActionResult POSTPassword([FromBody] Password input)
        {
            var result = input.IsValid();
            return Json(result);
        }
    }
}
