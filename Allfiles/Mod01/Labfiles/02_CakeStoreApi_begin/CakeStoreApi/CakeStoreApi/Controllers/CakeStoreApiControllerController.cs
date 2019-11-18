using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CakeStoreApi.Models;

namespace CakeStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakeStoreApiControllerController : ControllerBase
    {
        private IData _data;
        public CakeStoreApiControllerController(IData data)
        {
            _data = data;
        }
        [HttpGet("/api/CakeStore")]
        public ActionResult<List<CakeStore>> GetAll()
        {
            return _data.CakesInitializeData();
        }
        [HttpGet("/api/CakeStore/{id}")]
        public ActionResult<CakeStore> GetById(int? id)
        {
            var item = _data.GetCakeById(id);
            if(item == null)
            {
                return new NotFoundResult();
            }
            return new ObjectResult(item);
        }
    }
}