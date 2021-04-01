using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Data
{
    public class AItemDetailData : IItemDetailData
    {
        Project1Context context = new Project1Context();
        public AnItemDetail getItemDetail(int Id)
        {
            return context.AnItemDetails.SingleOrDefault(i => i.Id == Id);
        }
    }
}
