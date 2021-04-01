using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BuisnessLogic
{
    public class Logic
    {
        Project1Context context;
        public Logic()
        {
            context = new Project1Context();
        }

        /// <summary>
        /// creates a new order to assign order details to
        /// Automatically assigns the time that the method gets the order
        /// </summary>
        /// <param name="custID"></param>
        /// <param name="storeID"></param>
        /// <param name="tot"></param>
        /// <returns></returns>
        public Aorder NewOrder(int custID, int storeID, decimal tot)
        {
            var order = new Aorder()
            {
                CustomerId = custID,
                StoreId = storeID,
                Total = tot,
                OrderTime = DateTime.Now,
                OrderId = ((context.Aorders.Any(o => o.OrderId == 1)) ? context.Aorders.Max(o => o.OrderId) + 1 : 1)
            };
            context.Aorders.Add(order);
            context.SaveChanges();
            return order;
        }

        public int GetMaxOrderID()
        {
            return ((context.AorderDetails.Any(o => o.Id == 1)) ? context.AorderDetails.Max(o => o.Id) + 1 : 1);
        }

        /// <summary>
        /// Adds a new custmer
        /// </summary>
        /// <param name="cust"></param>
        /// <returns></returns>
        public Acustomer AddNewCustomer(Acustomer cust)
        {

            cust.Id = ((context.Acustomers.Any(c => c.Id == 1)) ? context.Acustomers.Max(o => o.Id) + 1 : 1);
            context.Acustomers.Add(cust);
            context.SaveChanges();
            return cust;
        }

        /// <summary>
        /// Creates new details of an order using the price and the amoung 
        /// </summary>
        /// <param name="orderNum"></param>
        /// <param name="itemNum"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public decimal NewOrderDetail(int orderNum, int itemNum, int amount,int detailnum)
        {
            Aorder getorder = context.Aorders.FirstOrDefault(o=> o.OrderId == orderNum);
            List<InventoryDetail> inventory = context.InventoryDetails.ToList();
            inventory.Find(i => getorder.StoreId == i.StoreId && itemNum == i.ItemId).Amount -= amount;
            context.InventoryDetails.Update(inventory.Find(i => getorder.StoreId == i.StoreId && itemNum == i.ItemId));
            context.SaveChanges();
           
                AorderDetail newDetail = new AorderDetail()
            {
                Id = detailnum,
                OrderId = orderNum,
                ItemId = itemNum,
                Total = Convert.ToDecimal(amount)

            };
            
            context.AorderDetails.Add(newDetail);
            context.SaveChanges();
            

            return 0.0m;
        }
        /// <summary>
        /// Checks inventory to see if the amount to go through is valid or not
        /// If it is return true. If it can't be fufiled return false.
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="storeid"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool ValidateOrderAmount(int itemid, int storeid, int amount)
        {
            var incomingItem = context.InventoryDetails.FirstOrDefault(i => i.ItemId == itemid && i.StoreId == storeid);
            if (incomingItem.Amount < amount)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
    }
}
