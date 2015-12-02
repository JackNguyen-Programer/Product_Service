using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class DALChiTietDH
    {
      
        static ServiceExportBill_Detail.ExportBill_DetailClient sExportBillDetail = new ServiceExportBill_Detail.ExportBill_DetailClient();
        static ServiceProduct.ProductClient sProduct = new ServiceProduct.ProductClient();
        static ServiceSave.SaveClient sSave = new ServiceSave.SaveClient();
        public static List<ExportBillDetail> GetCTDHByMaDH(int madh, DateTime day_bill)
        {    
            List<ServiceExportBill_Detail.export_bill_detail> le = sExportBillDetail.GetExportBill_DetailByIdExportBill(madh).ToList();
            if (le == null) return null;
            List<ExportBillDetail> listExport = new List<ExportBillDetail>();
            foreach (var item in le)
            {
                ExportBillDetail e = new ExportBillDetail();
                e.id_product = item.id_product;
                e.id_export_bill = item.id_export_bill;
                e.number = item.number;
                var pro = sProduct.GetProductById(item.id_product);
                e.name_product = pro.name;
                e.sale_price = pro.sale_price;
                e.id_save = pro.id_save;
                var save = sSave.GetSaveByIdAndDay(pro.id_save, day_bill);
                if(save != null) e.name_save = save.name;
                //
                e.date = day_bill;
                listExport.Add(e);
            }
            return listExport;
        }

        public static ServiceExportBill_Detail.export_bill_detail GetCTDHByMaSPMaDH(int masp, int madh)
        {
          
            ServiceExportBill_Detail.export_bill_detail e = sExportBillDetail.GetExportBill_DetailByBothId(masp, madh);
            return e;
        }
        public static List<ExportBillDetail> GetCTDHByMaSP(int masp)
        {       
            List<ServiceExportBill_Detail.export_bill_detail> le = sExportBillDetail.GetExportBill_DetailByIdProduct(masp).ToList();         
            if (le == null) return null;
            List<ExportBillDetail> listExport = new List<ExportBillDetail>();
            foreach (ServiceExportBill_Detail.export_bill_detail item in le)
            {
                ExportBillDetail e = new ExportBillDetail();
                e.id_product = item.id_product;
                e.id_export_bill = item.id_export_bill;
                e.number = item.number;
                var pro = sProduct.GetProductById(item.id_product);
                e.name_product = pro.name;
                e.sale_price = pro.sale_price;
                listExport.Add(e);
            }
            return listExport;
        }


        public static void Insert(ServiceExportBill_Detail.export_bill_detail ct)
        {            
            
            sExportBillDetail.AddExportBill_Detail(ct);
        }



        public static void Update(ServiceExportBill_Detail.export_bill_detail ct)
        {
            
            sExportBillDetail.UpdateExportBill_Detail(ct);
                      
        }

        //public static void Delete(ChiTietDH ct)
        //{
        //    //QLBHEntities db = new QLBHEntities();          
        //    //db.Entry(ct).State = EntityState.Deleted;
        //    //db.ChiTietDHs.Remove(ct);
        //    //db.SaveChanges();
        //}
        public static bool DeleteCT_DH(int id)
        {
            return sExportBillDetail.DeleteExportBill_DetailByIdExportBill(id);
        }
    }
}