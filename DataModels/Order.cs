using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Order
    {
        public int Id { get; set; }

        public int IdUser { get; set; }

        public User? User { get; set; }

        public DateTime PickupDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public double TotalPrice { get; set; }

        public ICollection<ItemOrder>? ItemOrders { get; set; }  
    }
}
