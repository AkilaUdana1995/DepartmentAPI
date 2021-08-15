using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentAPI.Models
{
    public class Order
    {
        public int orderId { get; set; }
        public int orderNo { get; set; }
        public int CustId { get; set; }
        public decimal FinalValue { get; set; }   //To this FinalValue We need to set value "InclAmount" I have implemented function to calculate it in "SellingsController" ; I have documented all concept in my documentation...
    }
}
