
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Data.Entity.Infrastructure;

namespace BanHang.Models
{
    public class DALSanPham
    {
        private static ServiceProduct.ProductClient sProduct = new ServiceProduct.ProductClient();
        private static ServiceSave.SaveClient sSave = new ServiceSave.SaveClient();
        private static ServiceManufacturer.ManufacturerClient sManu = new ServiceManufacturer.ManufacturerClient();
        private static ServiceSaveDate.Save_DateClient sSaveDate = new ServiceSaveDate.Save_DateClient();

        public static List<Product> GetAllSanPham()
        {
            List<ServiceProduct.product> myProduct = sProduct.GetAllProduct().ToList();
            
            return ConvertListProduct(myProduct); ;
        }
        public static IPagedList<Product> GetAllSanPhamPhanTrang(string hangsx, int? page)
        {

            int pageSize = 9;
            int pageNum = (page ?? 1);
            List<ServiceProduct.product> listSP = sProduct.GetAllProductOrByNameManu(hangsx).ToList();
            return ConvertListProduct(listSP).ToPagedList(pageNum, pageSize);
        }

        public static IPagedList<Product> GetSanPhamPhanTrang(string ten, int? page)
        {
            int pageSize = 9;
            int pageNum = (page ?? 1);
            List<ServiceProduct.product> listSP = sProduct.GetProductByName(ten).ToList();
            return ConvertListProduct(listSP).ToPagedList(pageNum, pageSize);
        }

        public static IPagedList<Product> GetSanPhanMoi(int? page)
        {
            int pageSize = 9;
            int pageNum = (page ?? 1);
            List<ServiceProduct.product> listSP = sProduct.GetNewProduct().ToList();
            return ConvertListProduct(listSP).ToPagedList(pageNum, pageSize);
        }

        public static IPagedList<Product> GetSanPhanGiamGia(int? page)
        {
            int pageSize = 9;
            int pageNum = (page ?? 1);
            List<ServiceProduct.product> listSP = sProduct.GetProductSave().ToList();
            return ConvertListProduct(listSP).ToPagedList(pageNum, pageSize);
        }
        public static IPagedList<Product> GetSanPhanGiamGia(int? page, int id_save)
        {
            int pageSize = 9;
            int pageNum = (page ?? 1);
            List<ServiceProduct.product> listSP = sProduct.GetProductByIdSave(id_save).ToList();
            return ConvertListProduct(listSP).ToPagedList(pageNum, pageSize);
        }
        public static IPagedList<ServiceSave.save> GetAllGiamGia(int? page)
        {
            try
            {
                int pageSize = 5;
                int pageNum = (page ?? 1);
                List<ServiceSave.save> listS = sSave.GetSaveByDay(DateTime.Now).ToList();
                List<ServiceSave.save> listS2 = sSave.GetSaveNotSaveDay().ToList();
                if (listS2.Count > 0)
                    listS.AddRange(listS2);
                return listS.ToPagedList(pageNum, pageSize);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static Save GetChiTietGiamGia(int id_save)
        {
            Save my_save = new Save();
            var save = sSave.GetSaveWithId(id_save);
            my_save.id = save.id;
            my_save.name = save.name;
            my_save.percent = save.percent_save;
            my_save.content = save.content_save;
            my_save.image = save.image;
            var save_day = sSaveDate.GetSaveDateWithIdSave(id_save);
            foreach (var item in save_day)
            {
                var dayNow = DateTime.Now;
                if (item.date_start <= dayNow && item.date_end >= dayNow)
                {
                    my_save.date_start = item.date_start;
                    my_save.date_end = item.date_end;
                }
            }
            
            return my_save;
        }

        public static List<ServiceSaveDate.save_date> GetListSaveDayByIdSave(int id_save)
        {
            return sSaveDate.GetSaveDateWithIdSave(id_save).ToList();
        }
        public static Product GetSanPhamByMaSP(int id)
        {
            ServiceProduct.product p = sProduct.GetProductById(id);
            return ConvertProduct(p);
        }

        public static List<Product> GetSanPhamByTen(string ten)
        {
            List<ServiceProduct.product> lp = sProduct.GetProductByName(ten).ToList();
            return ConvertListProduct(lp).ToList();
        }

        public static List<Product> GetSanPhamByMaHang(int maHang)
        {
            List<ServiceProduct.product> lp = sProduct.GetProductByIdManu(maHang).ToList();
            return ConvertListProduct(lp).ToList();
        }

        public static List<Product> GetSanPhamByTenHang(string tenHang)
        {
            List<ServiceProduct.product> lp = sProduct.GetProductByNameManu(tenHang).ToList();
            return ConvertListProduct(lp).ToList();
        }

        public static List<Product> GetSanPhamByHangAndTenSP(int hang, string ten)
        {
            List<ServiceProduct.product> lp = sProduct.GetProductByIdManuAndNameProduct(hang, ten).ToList();
            return ConvertListProduct(lp).ToList();
        }

        public static List<ServiceManufacturer.manufacturer> GetAllHang()
        {
            List<ServiceManufacturer.manufacturer> lm = sManu.GetAllManufacturer().ToList();
            return lm;
        }

        public static ServiceManufacturer.manufacturer GetHangByTen(string ten)
        {
            ServiceManufacturer.manufacturer m = sManu.GetManufacturerByName(ten);
            return m;
        }

        public static void Insert(ServiceProduct.product sp)
        {
            sProduct.AddProduct(sp);
        }

        public static void Update(ServiceProduct.product sp)
        {
            sProduct.UpdateProduct(sp);
        }

        public static ServiceSave.save GetSaveById(int id)
        {
            return sSave.GetSaveWithId(id);
        }
        public static bool DeleteSanPham(int idSP)
        {
            return sProduct.DeleteProduct(idSP);
        }

        private static List<Product> ConvertListProduct(List<ServiceProduct.product> myProduct)
        {
            List<Product> listProduct = new List<Product>();
            foreach (ServiceProduct.product item in myProduct)
            {
                Product p = new Product();
                p.id = item.id;
                p.id_manufacturer = item.id_manufacturer;
                p.id_save = item.id_save;
                p.manufacturer = sManu.GetManufacturerById(item.id_manufacturer).name;
                var s = sSave.GetSaveWithId(item.id_save);
                p.save = s.percent_save;
                p.name_save = s.name;
                p.name = item.name;
                p.product_info = item.product_info;
                p.sale_price = item.sale_price;
                p.number = item.number;
                p.image = item.image;
                listProduct.Add(p);
            }
            return listProduct;
        }
        private static Product ConvertProduct(ServiceProduct.product myProduct)
        {
            Product p = new Product();
            p.id = myProduct.id;
            p.id_manufacturer = myProduct.id_manufacturer;
            p.id_save = myProduct.id_save;
            p.manufacturer = sManu.GetManufacturerById(myProduct.id_manufacturer).name;
            var s = sSave.GetSaveWithId(myProduct.id_save);
            p.save = s.percent_save;
            p.name_save = s.name;
            p.name = myProduct.name;
            p.product_info = myProduct.product_info;
            p.sale_price = myProduct.sale_price;
            p.number = myProduct.number;
            p.image = myProduct.image;
            return p;
        }
    }
}
