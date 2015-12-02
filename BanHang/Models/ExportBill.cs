using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class ExportBill
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int id_user { get; set; }
        public decimal total_price { get; set; }
        public int status { get; set; }
        public string name_user { get; set; }
        public string email_user { get; set; }
        public string phone_number { get; set; }
    }
}