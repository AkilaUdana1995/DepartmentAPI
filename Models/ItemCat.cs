using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentAPI.Models
{
    public class ItemCat
    {
        public int ItemId { get; set; }   //this help to add/edit/view and delete item from inventary...
        public string ItemCode { get; set; }
        public decimal IemPrice { get; set; }
        public string ItemNote { get; set; }


    }
}
