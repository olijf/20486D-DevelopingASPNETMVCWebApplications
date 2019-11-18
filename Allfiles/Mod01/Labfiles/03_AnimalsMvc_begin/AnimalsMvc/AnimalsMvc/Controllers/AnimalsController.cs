using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalsMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsMvc.Controllers
{
    public class AnimalsController : Controller
    {
        private IData _tempData;
        public AnimalsController(IData tempData)
        {
            _tempData = tempData;
        }
        public IActionResult Index()
        {
            var animals = _tempData.AnimalsInitializeData();
            var indexViewModel = new IndexViewModel();
            indexViewModel.Animals = animals;
            return View(indexViewModel);
        }
        public IActionResult Details(int? id)
        {
            var model = _tempData.GetAnimalById(id);
            if(id == null)
            {
                return new NotFoundResult();
            }
            return View(model);
        }
    }
}