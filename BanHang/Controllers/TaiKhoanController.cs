using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using BanHang.Models;
using System.Web.UI;
using System.Data;
using System.Data.Entity.Infrastructure;



namespace BanHang.Controllers
{
    [Authorize]

    public class TaiKhoanController : Controller
    {


        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string pass)
        {

            if (ModelState.IsValid)
            {
                if (DALKhachHang.CheckEmailAndPass(email, pass) == true)
                {
                    FormsAuthentication.SetAuthCookie(email, true);
                    return Redirect(Url.Action("Index", "SanPham"));
                }
                else
                {
                    ModelState.AddModelError("", "Nhập sai email hoặc mật khẩu");
                    return View();
                }

            }
            else
                return View();
        }



        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            //WebSecurity.Logout();

            return RedirectToAction("Index", "SanPham");
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(ServiceUser.user kh)
        {
            if (ModelState.IsValid)
            {
                if (DALKhachHang.CheckEmailExisted(kh.email) == false)
                {
                    kh.id_role = 1;//user default is khachhang
                    if (DALKhachHang.Insert(kh))
                        return Login(kh.email, kh.password);
                    ModelState.AddModelError("", "Không thể thêm User");
                }
                else
                    ModelState.AddModelError("", "Email đã tồn tại");

            }

            return View();
        }

        public ActionResult Manage()
        {
            return View(DALKhachHang.GetKhachHangByEmail(User.Identity.Name));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(ServiceUser.user kh)
        {

            if (ModelState.IsValid)
            {
                //if (DALKhachHang.CheckEmailExisted(kh.email) == true && kh.email != User.Identity.Name)
                //{
                //    ModelState.AddModelError("", "Email đã tồn tại");
                //}
                //else
                //{
                //FormsAuthentication.SetAuthCookie(kh.email, true);
                //string e = kh.email;
                //string p = kh.password;
                //var user = DALKhachHang.GetKhachHangByEmail(kh.email);
                //user.password = kh.password;
                //user.name = kh.name;
                //user.phone_number = kh.phone_number;
                //user.address = kh.address;
                if (DALKhachHang.Update(kh))
                {
                    TempData["message"] = "Cập nhật thành công!";
                    //FormsAuthentication.SetAuthCookie(kh.email, true);
                    return RedirectToAction("Manage");
                }
                else
                {
                    //ModelState.AddModelError("", "Cập nhật thất bại");
                    TempData["message"] = "Cập nhật thất bại!";
                    //FormsAuthentication.SetAuthCookie(kh.email, true);
                    return RedirectToAction("Manage");
                }
                //}
            }
            return View(kh);
        }

        // GET: /Account/Invoice

        //public ActionResult Invoices(string tu,string den)
        //{
        //   // KhachHang kh= GetKhachHangbyEmail();

        //    if (tu == null && den == null)
        //        return View(DALDonHang.GetDonHangByEmail(User.Identity.Name.ToString()).OrderByDescending(a=>a.date));
        //    else 
        //    {           
        //        DateTime denngay, tungay;
        //        if (tu == "" || tu == null)
        //            tungay = new DateTime(2000, 1, 1);
        //        else
        //            tungay = DateTime.Parse(tu);
        //        if (den == null || den == "")
        //            denngay = DateTime.Now;
        //        else
        //            denngay = DateTime.Parse(den);
        //        return View(DALDonHang.GetDonHangByEmailAndDate(User.Identity.Name.ToString(), tungay, denngay));
        //    } 
        //}



        public ActionResult LineItem(int madh, DateTime day_bill)
        {
            return View(DALChiTietDH.GetCTDHByMaDH(madh, day_bill));
        }


        //public ActionResult Invoice(string tu,string den, int ? page)
        //{
        //    if (tu == null && den == null)
        //        return View(DALDonHang.GetDonHangByEmailPT(User.Identity.Name.ToString(), page));
        //    else
        //    {
        //        ViewBag.tu = tu;
        //        ViewBag.den = den;
        //        DateTime denngay, tungay;
        //        if (tu == "" || tu == null)
        //            tungay = new DateTime(2000, 1, 1);
        //        else
        //            tungay = DateTime.Parse(tu);
        //        if (den == null || den == "")
        //            denngay = DateTime.Now;
        //        else
        //            denngay = DateTime.Parse(den);
        //        return View(DALDonHang.GetDonHangByEmailAndDatePT(User.Identity.Name.ToString(), tungay, denngay,page));
        //    }
        //}



    }

}
