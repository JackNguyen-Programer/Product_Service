using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class DALChiTietDNH
    {
      
        static ServiceImportBill_Detail.ImportBill_DetailClient sImportBillDetail = new ServiceImportBill_Detail.ImportBill_DetailClient();
        public static List<ServiceImportBill_Detail.import_bill_detail> GetCTDHByMaDH(int madnh)
        {
          
            List<ServiceImportBill_Detail.import_bill_detail> li = sImportBillDetail.GetImportBill_DetailByIdImportBill(madnh).ToList();
            return li;
        }

        public static ServiceImportBill_Detail.import_bill_detail GetCTDHByMaSPMaDNH(int masp, int madnh)
        {
            
            ServiceImportBill_Detail.import_bill_detail i = sImportBillDetail.GetImportBill_DetailByBothId(masp, madnh);
            return i;
        }
        public static List<ServiceImportBill_Detail.import_bill_detail> GetCTDHByMaSP(int masp)
        {
            
            List<ServiceImportBill_Detail.import_bill_detail> li = sImportBillDetail.GetImportBill_DetailByIdProduct(masp).ToList();
            return li;
        }


        public static void Insert(ServiceImportBill_Detail.import_bill_detail ct)
        {      
           
            sImportBillDetail.AddImportBill_Detail(ct);
        }



        public static void Update(ServiceImportBill_Detail.import_bill_detail ct)
        {
            
            sImportBillDetail.UpdateImportBill_Detail(ct);
        }

        //public static void Delete(ChiTietDNH ct)
        //{
        //    //QLBHEntities db = new QLBHEntities();
        //    //ChiTietDNH existing = db.ChiTietDNHs.Where(p => p.MaDNH == ct.MaDNH && p.MaSP == ct.MaSP).First();
        //    //((IObjectContextAdapter)db).ObjectContext.Detach(existing);
        //    //db.Entry(ct).State = EntityState.Deleted;
        //    //db.ChiTietDNHs.Remove(ct);
        //    //db.SaveChanges();
        //}

        public static bool DeleteCT_DNH(int id)
        {
            return sImportBillDetail.DeleteImportBill_DetailByIdImportBill(id);
        }
    }
}