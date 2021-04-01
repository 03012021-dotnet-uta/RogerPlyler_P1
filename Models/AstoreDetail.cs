using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class AstoreDetail
    {
        public int Id { get; set; }
        public string Descript { get; set; }
        public string SrcImg { get; set; }

        public virtual Astore IdNavigation { get; set; }
    }
}
