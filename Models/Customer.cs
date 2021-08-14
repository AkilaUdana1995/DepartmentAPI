using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentAPI.Models
{
    public class Customer
    {
        public int CustId { get; set; }
        public string CustName { get; set; }
        public string CAddress1 { get; set; }
        public string CAddress2 { get; set; }
        public string CAdress3 { get; set; }
        public string SubRub { get; set; }
        public string CState { get; set; }
        public string Postal { get; set; }
        public int InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int RefferenceNo { get; set; }
        public string Notes { get; set; }
    }
}
