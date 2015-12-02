
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class DALDonNhapHang
    {
       
        static ServiceImportBill.ImportBillClient sImportBill = new ServiceImportBill.ImportBillClient();
        static ServiceManufacturer.ManufacturerClient sManu = new ServiceManufacturer.ManufacturerClient();
        private static List<ImportBill> ConvertListImportBill(List<ServiceImportBill.import_bill> myImport)
        {
            List<ImportBill> listImport = new List<ImportBill>();
            foreach (var item in myImport)
            {
                ImportBill import = new ImportBill();
                import.id = item.id;
                import.date = item.date;
                import.id_manufacturer = item.id_manufacturer;
                import.total_price = item.total_price;
                import.name_manufacturer = sManu.GetManufacturerById(item.id_manufacturer).name;
                listImport.Add(import);
            }
            return listImport;
        }
        private static ImportBill ConvertImportBill(ServiceImportBill.import_bill item)
        {
            ImportBill import = new ImportBill();
            import.id = item.id;
            import.date = item.date;
            import.id_manufacturer = item.id_manufacturer;
            import.total_price = item.total_price;
            import.name_manufacturer = sManu.GetManufacturerById(item.id_manufacturer).name;
            return import;
        }
        public static List<ImportBill> GetAllDonNhapHang()
        {         
            List<ServiceImportBill.import_bill> li = sImportBill.GetAllImportBill().ToList();
            return ConvertListImportBill(li).ToList();
        }

        public static ImportBill GetDonNhapHangById(int id)
        {         
            ServiceImportBill.import_bill i = sImportBill.GetImportBillById(id);
            return ConvertImportBill(i);
        }


        public static List<ImportBill> GetDonNhapHangByNgay(DateTime tu, DateTime den)
        {        
            List<ServiceImportBill.import_bill> li = sImportBill.GetImportBillFromTo(tu, den).ToList();
            return ConvertListImportBill(li).ToList();
        }

        public static List<ImportBill> GetDonNhapHangByMaHang(int idHang)
        {          
            List<ServiceImportBill.import_bill> li = sImportBill.GetImportBillByIdManu(idHang).ToList();
            return ConvertListImportBill(li).ToList();
        }

        //public static int GetMaDNH()
        //{
        //    //QLBHEntities db = new QLBHEntities();
        //    //return (db.DonNhapHangs.AsNoTracking().OrderByDescending(i => i.MaDNH).First().MaDNH+1);
        //}



        public static void Insert(ServiceImportBill.import_bill dnh)
        {          
            sImportBill.AddImportBill(dnh);
        }

        public static void Update(ServiceImportBill.import_bill dnh)
        {         
            sImportBill.UpdateImportBill(dnh);
        }

        //public static void Delete(DonNhapHang dnh)
        //{
        //    QLBHEntities db = new QLBHEntities();
        //    DonNhapHang existing = db.DonNhapHangs.Where(p => p.MaDNH == dnh.MaDNH).First();
        //    ((IObjectContextAdapter)db).ObjectContext.Detach(existing);
        //    db.Entry(dnh).State = EntityState.Deleted;
        //    db.DonNhapHangs.Remove(dnh);
        //    db.SaveChanges();
        //} 
        public static bool DeleteDNH(int id)
        {
            return sImportBill.DeleteImportBill(id);
        }
    }
}