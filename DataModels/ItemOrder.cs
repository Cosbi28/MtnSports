using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class ItemOrder : EntityModel
    {
        public int IdOrder { get; set; }

        public int IdItem { get; set; }

        public int Quantity { get; set; }
    }
}
