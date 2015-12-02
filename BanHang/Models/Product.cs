using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class Product
    {
        public int id { get; set; }
        public int id_save { get; set; }
        public int id_manufacturer { get; set; }
        public string manufacturer { get; set; }
        public int save { get; set; }
        public string name { get; set; }
        public string product_info { get; set; }
        public decimal sale_price { get; set; }
        public int number { get; set; }
        public string image { get; set; }
        public string name_save { get; set; }
    }
}