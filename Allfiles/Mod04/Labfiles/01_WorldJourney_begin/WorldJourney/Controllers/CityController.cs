using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using WorldJourney.Models;
using WorldJourney.Filters;

namespace WorldJourney.Controllers
{
    public class CityController : Controller
    {
        private IData _data;
        private IHostingEnvironment _environment;
        public CityController(IData data, IHostingEnvironment hosting)
        {
            _data = data;
            _environment = hosting;
            _data.CityInitializeData();
        }
        [Route("WorldJourney")]
        [ServiceFilter(typeof(LogActionFilterAttribute))]
        public IActionResult Index()
        {
            ViewData["Page"] = "Search City";
            return View();
        }
        [Route("CityDetails/{id?}")]
        public IActionResult Details(int? Id)
        {
            ViewData["Page"] = "Selected City";
            City city = _data.GetCityById(Id);
            if (city == null)
            {
                return NotFound();
            }

            ViewBag.Title = city.CityName;
            return View(city);
        }
        public IActionResult GetImage(int? CityId)
        {
            ViewData["Message"] = "Display Image";
            City requestedCity = _data.GetCityById(CityId);
            if (requestedCity != null)
            {
                var webRootPath = _environment.WebRootPath;
                var folderPath = @"images\";
                var fullPath = Path.Combine(webRootPath, folderPath, requestedCity.ImageName);
                var fileOnDisk = new FileStream(fullPath, FileMode.Open);
                Byte[] fileBytes;
                using (var br = new BinaryReader(fileOnDisk))
                {
                    fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                }
                return File(fileBytes, requestedCity.ImageMimeType, fileOnDisk.Name);

            }
            return NotFound();
        }
    }
}