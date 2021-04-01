using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace Repository.Data
{
    public interface IItemDetailData
    {
        AnItemDetail getItemDetail(int Id);
    }
}
