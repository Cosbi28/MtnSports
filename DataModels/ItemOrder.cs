using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class ItemOrder
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }

        public Order? Order { get; set; }

        public int IdItem { get; set; }

        public Item? Item { get; set; }

        public int Quantity { get; set; }
    }
}
