using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class AnItem
    {
        public AnItem()
        {
            AorderDetails = new HashSet<AorderDetail>();
            InventoryDetails = new HashSet<InventoryDetail>();
        }

        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal? Price { get; set; }

        public virtual AnItemDetail AnItemDetail { get; set; }
        public virtual ICollection<AorderDetail> AorderDetails { get; set; }
        public virtual ICollection<InventoryDetail> InventoryDetails { get; set; }
    }
}
