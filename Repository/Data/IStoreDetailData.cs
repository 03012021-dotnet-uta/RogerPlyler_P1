using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data
{
    public interface IStoreDetailData
    {
        List<AstoreDetail>  GetStoreDetails();
        AstoreDetail GetStoreDetail(int ID);
    }
}
