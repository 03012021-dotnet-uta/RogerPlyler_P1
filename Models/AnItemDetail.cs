using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class AnItemDetail
    {
        public int Id { get; set; }
        public string Descript { get; set; }
        public string SrcImg { get; set; }

        public virtual AnItem IdNavigation { get; set; }
    }
}
