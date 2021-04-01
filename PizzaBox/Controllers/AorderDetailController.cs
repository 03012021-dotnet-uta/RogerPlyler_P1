using Microsoft.AspNetCore.Mvc;
using Models;
using Repository.Data;
using BuisnessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Controllers
{
    [ApiController]
    public class AorderDetailController : Controller
    {
        private IOrderDetail orderDetails;
        public AorderDetailController(IOrderDetail _orderDetails)
        {
            orderDetails = _orderDetails;
        }
        [HttpGet]
        [Route("api/[controller]/max")]
        public IActionResult IOrderNum()
        {
            Logic buis = new Logic();
            return Ok(buis.GetMaxOrderID());

        }

         
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult getOrderDetails(int id) //NOTE: LOOK UP IF YOU NEED THE THING IN THE URL NEEDS OT MATCH WHAT IS CALLED
        {
            List<AorderDetail> orders = orderDetails.GetOrderDetails(id);
            return Ok(orders);
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult getAllOrders()
        {
            return Ok(orderDetails.GetAllOrderDetails());
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult addOrderDetail(AorderDetail newOrderDetail)
        {
            orderDetails.AddOrderDetail(newOrderDetail);
            return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/submit/{ordernum}/{itemnum}/{amount}/{detailnum}")]
        public IActionResult addOrderDetails(int ordernum,int itemnum,int amount,int detailnum)
        {
            Logic buis = new Logic();
            buis.NewOrderDetail(ordernum, itemnum, amount,detailnum);
            return Ok(100);
        }
    }
}
