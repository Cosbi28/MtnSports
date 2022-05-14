using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class SearchViewModel
    {
        public string ItemName { get; set; }
        public DateTime PickUpDate  { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
