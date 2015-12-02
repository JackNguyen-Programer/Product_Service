using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class ImportBill
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int id_manufacturer { get; set; }
        public decimal total_price { get; set; }
        public string name_manufacturer { get; set; }
    }
}