using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHang.Models;


namespace BanHang.Controllers
{
    public class SanPhamController : Controller
    {

        public ActionResult Index(string hangsx, int? page)
        {
            ViewBag.hangsx = hangsx;
            return View(DALSanPham.GetAllSanPhamPhanTrang(hangsx, page));
            
        }      

        public ActionResult Detail(int id)
        {
            using (ServiceManufacturer.ManufacturerClient manu = new ServiceManufacturer.ManufacturerClient())
            {
                Product sp = DALSanPham.GetSanPhamByMaSP(id);            
                if (sp == null)
                {
                    return HttpNotFound();
                }
                return View(sp);
            }
        }

        public PartialViewResult LeftMenu()
        {
            return PartialView(DALSanPham.GetAllHang());
        }

        public PartialViewResult SearchBox()
        {        
            return PartialView();
        }

        public ActionResult SearchResult(string ten, int? page)
        {
            System.Diagnostics.Debug.WriteLine(ten);
            if (ModelState.IsValid)
            {
                ViewBag.ten = ten;
                return View(DALSanPham.GetSanPhamPhanTrang(ten, page));
            }
            else
                return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult NewProduct(int? page) 
        {
            return View(DALSanPham.GetSanPhanMoi(page));
        }
        public ActionResult ProductSave(int? page, int id_save)
        {
            PagedList.IPagedList<Product> list;
            if (id_save < 1)
                list = DALSanPham.GetSanPhanGiamGia(page);
            else
            {
                list = DALSanPham.GetSanPhanGiamGia(page, id_save);
            }
            if (list.Count < 1) list = DALSanPham.GetAllSanPhamPhanTrang(null, page);
            return View(list);
        }
        
        public ActionResult Save(int? page)
        {
            return View(DALSanPham.GetAllGiamGia(page));
        }
        public ActionResult SaveDetail(int id_save)
        {
            return View(DALSanPham.GetChiTietGiamGia(id_save));
        }
        public PartialViewResult SaveDetail_Day(int id_save)
        {
            return PartialView(DALSanPham.GetListSaveDayByIdSave(id_save));
        }
        public PartialViewResult SaveIcon(int id_save, int percent)
        {
            ViewBag.IdSave = id_save;
            ViewBag.PercentSave = percent;
            return PartialView();
        }
    }
}
