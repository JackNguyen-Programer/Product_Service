using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class User
    {
        public int id { get; set; }
        public int id_role { get; set; }
        public string name_role { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
    }
}