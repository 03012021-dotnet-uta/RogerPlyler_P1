using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Astore
    {
        public Astore()
        {
            Aorders = new HashSet<Aorder>();
            InventoryDetails = new HashSet<InventoryDetail>();
        }

        public int Id { get; set; }
        public string StoreName { get; set; }

        public virtual AstoreDetail AstoreDetail { get; set; }
        public virtual ICollection<Aorder> Aorders { get; set; }
        public virtual ICollection<InventoryDetail> InventoryDetails { get; set; }
    }
}
