using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class ExportBillDetail
    {
        public int id_product { get; set; }
        public int id_export_bill { get; set; }
        public int number { get; set; }
        public decimal sale_price { get; set; }
        public string name_product { get; set; }
        public int number_product { get; set; }
        public int id_save { get; set; }
        public string name_save { get; set; }
        public int percent_save { get; set; }
        public DateTime date { get; set; }
    }
}