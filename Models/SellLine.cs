using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentAPI.Models
{
    public class SellLine
    {
        public int SN { get; set; }
        public int ItemId { get; set; }
        public decimal IemPrice { get; set; }
        public int QTY { get; set; }
        public int TAX { get; set; }
        //public float ExclAmount { get; set; }    //these calculations are done ; Dont need to add them as fixed columns in table... we can use concept table joining...
        //public float TaxAmount { get; set; }
        //public float InclAmount { get; set; }




    }
}
