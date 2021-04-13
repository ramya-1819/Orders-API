using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectAPI.Models
{
    public class Orders
    {
        public int Pno { get; set; }
        public int Custno { get; set; }
        public  DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string Tocity { get; set; }
        public string Items { get; set; }
        public string OrderDescription { get; set; }
    }
}