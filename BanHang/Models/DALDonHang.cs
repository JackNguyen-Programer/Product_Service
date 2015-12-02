using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class DALDonHang
    {        
        static ServiceExportBill.ExportBillClient sExportBill = new ServiceExportBill.ExportBillClient();
        static ServiceUser.UserClient sUser = new ServiceUser.UserClient();
        private static List<ExportBill> ConvertListExportBill(List<ServiceExportBill.export_bill> myListExport)
        {
            List<ExportBill> listExport = new List<ExportBill>();
            foreach (var item in myListExport)
            {
                ExportBill ex = new ExportBill();
                ex.id = item.id;
                ex.date = item.date;
                ex.id_user = item.id_user;
                ex.total_price = item.total_price;
                ex.status = item.status;
                var u = sUser.GetUserById(item.id_user);
                ex.name_user = u.name;
                ex.email_user = u.email;
                ex.phone_number = u.phone_number;
                listExport.Add(ex);
            }
            return listExport;
        }
        private static ExportBill ConvertExportBill(ServiceExportBill.export_bill item)
        {
            ExportBill ex = new ExportBill();
            ex.id = item.id;
            ex.date = item.date;
            ex.id_user = item.id_user;
            ex.total_price = item.total_price;
            ex.status = item.status;
            var u = sUser.GetUserById(item.id_user);
            ex.name_user = u.name;
            ex.email_user = u.email;
            ex.phone_number = u.phone_number;
            return ex;
        }

        public static List<ExportBill> GetAllDonHang()
        {           
            List<ServiceExportBill.export_bill> le = sExportBill.GetAllExportBill().ToList();
            return ConvertListExportBill(le).ToList();
        }

        public static ExportBill GetDonHangById(int id)
        {         
            ServiceExportBill.export_bill e = sExportBill.GetExportBillById(id);
            return ConvertExportBill(e);
        }

        public static List<ExportBill> GetDonHangByEmail(string email)
        {          
            List<ServiceExportBill.export_bill> le = sExportBill.GetExportBillByEmail(email).ToList();
            return ConvertListExportBill(le).ToList();
        }

        public static IPagedList<ExportBill> GetDonHangByEmailPT(string email, int? page)
        {          
            int pageSize = 10;
            int pageNum = (page ?? 1);
            //IPagedList<ServiceExportBill.export_bill> lPage = sExportBill.GetExportBillByEmail(email).ToPagedList(pageNum, pageSize);         
            //if (lPage == null)
            //{
            //    return null;
            //}
            List<ServiceExportBill.export_bill> lPage = sExportBill.GetExportBillByEmail(email).ToList();
            return ConvertListExportBill(lPage).ToPagedList(pageNum, pageSize);
        }

        public static IPagedList<ExportBill> GetDonHangByEmailAndDatePT(string email, DateTime tu, DateTime den, int? page)     
        {           
            int pageSize = 10;
            int pageNum = (page ?? 1);
            //IPagedList<ServiceExportBill.export_bill> pageList = sExportBill.GetExportBillByEmailAndDateFromTo(email, tu, den).ToPagedList(pageNum, pageSize);
            List<ServiceExportBill.export_bill> list = sExportBill.GetExportBillByEmailAndDateFromTo(email, tu, den).ToList();
            return ConvertListExportBill(list).ToPagedList(pageNum, pageSize);
        }

        public static List<ExportBill> GetDonHangByNgayDH(DateTime tu, DateTime den)
        {          
            List<ServiceExportBill.export_bill> le = sExportBill.GetExportBillByDateFromTo(tu, den).ToList();
            return ConvertListExportBill(le).ToList();
        }

        public static List<ExportBill> GetDonHangByEmailAndDate(string email, DateTime tu, DateTime den)
        {          
            List<ServiceExportBill.export_bill> le = sExportBill.GetExportBillByEmailAndDateFromTo(email, tu, den).ToList();
            return ConvertListExportBill(le).ToList();
        }

        public static ExportBill GetTheLastDonHang()
        {        
            ServiceExportBill.export_bill e = sExportBill.GetLastExportBill();
            return ConvertExportBill(e);
        }

        public static void Insert(ServiceExportBill.export_bill dh)
        {
            
            sExportBill.AddExportBill(dh);
        }

        public static void Update(ServiceExportBill.export_bill dh)
        {
           
            sExportBill.UpdateExportBill(dh);
        }

        public static bool DeleteDH(int id)
        {
            return sExportBill.DeleteExportBillById(id);
        }
    }
}