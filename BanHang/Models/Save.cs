using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class Save
    {
        public int id { get; set; }
        public string name { get; set; }
        public int percent { get; set; }
        public string content { get; set; }
        public DateTime date_start { get; set; }
        public DateTime date_end { get; set; }
        public string image { get; set; }
    }
}