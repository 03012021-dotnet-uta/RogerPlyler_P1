using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Controllers
{
    [ApiController]
    public class AnItemDetailController : Controller
    {

        private IItemDetailData itemData;
        public AnItemDetailController(IItemDetailData _itemData)
        {
            itemData = _itemData;
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetItemDetail(int id)
        {
            return Ok(itemData.getItemDetail(id));
        }
    }
}
