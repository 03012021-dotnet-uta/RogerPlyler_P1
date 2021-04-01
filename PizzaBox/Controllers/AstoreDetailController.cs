using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Controllers
{
    [ApiController]
    public class AstoreDetailController : Controller
    {
        private IStoreDetailData storeData;
        public AstoreDetailController(IStoreDetailData _storeData)
        {
            storeData = _storeData;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetStores()
        {
            return Ok(storeData.GetStoreDetails());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetStore(int id)
        {
            return Ok(storeData.GetStoreDetail(id));
        }
    }
}
