using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BanHang.Controllers
{
    [Authorize]

    public class TaiKhoanController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
    }

}
