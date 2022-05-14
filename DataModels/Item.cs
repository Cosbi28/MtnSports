using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public string Brand { get; set; }

        public string Size { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public int Stock { get; set; }

        public ICollection<ItemOrder>? ItemOrders { get; set; }
    }
}
