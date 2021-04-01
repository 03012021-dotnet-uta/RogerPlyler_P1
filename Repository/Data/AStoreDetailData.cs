using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Repository.Data
{
    public class AStoreDetailData :IStoreDetailData
    {
        Project1Context context = new Project1Context();

        public AstoreDetail GetStoreDetail(int ID)
        {
            return context.AstoreDetails.SingleOrDefault(s => s.Id == ID);
        }

        public List<AstoreDetail> GetStoreDetails()
        {
            return context.AstoreDetails.ToList();
        }
    }
}
