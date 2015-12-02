using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;
using System.Diagnostics;
using System.Data;
using System.Data.Entity;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ExportBill" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ExportBill.svc or ExportBill.svc.cs at the Solution Explorer and start debugging.
    public class ExportBill : IExportBill
    {

        public List<export_bill> GetAllExportBill()
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var my_data = (data.export_bill.Select(p => p)).ToList();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public export_bill GetExportBillById(int id)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var my_data = data.export_bill.First(s => s.id == id);
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public bool AddExportBill(export_bill eb)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    data.export_bill.Add(eb);
                    data.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public bool UpdateExportBill(export_bill eb)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {                
                    data.Entry(eb).State = System.Data.Entity.EntityState.Modified;                  
                    data.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }


        public List<export_bill> GetExportBillByEmail(string email)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var my_data = data.export_bill.AsNoTracking()
                        .Where(e => e.user.email.ToUpper().Contains(email) || e.user.email.ToLower().Contains(email)).ToList();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<export_bill> GetExportBillByDateFromTo(DateTime from, DateTime to)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var my_data = data.export_bill.AsNoTracking()
                        .Where(e => e.date >= from && e.date <= to).ToList();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<export_bill> GetExportBillByEmailAndDateFromTo(string email, DateTime from, DateTime to)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var my_data = data.export_bill.AsNoTracking()
                        .Where(e => e.date >= from && e.date <= to && e.user.email.Contains(email)).ToList();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public export_bill GetLastExportBill()
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var my_data = data.export_bill.AsNoTracking()
                        .OrderByDescending(e => e.id).First();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }


        public bool DeleteExportBillByIdUser(int idUser)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var listExport = data.export_bill.Where(e => e.id_user == idUser).ToList();
                    foreach (var item in listExport)
                    {
                        var exportBill_Detail = data.export_bill_detail.Where(e => e.id_export_bill == item.id).ToList();
                        foreach (var item2 in exportBill_Detail)
                        {
                            data.export_bill_detail.Remove(item2);
                        }
                        data.export_bill.Remove(item);
                    }
                    return true;                
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public bool DeleteExportBillById(int id)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var export = data.export_bill.Single(e => e.id == id);
                    var exportBill_Detail = data.export_bill_detail.Where(e => e.id_export_bill == id).ToList();
                    foreach (var item in exportBill_Detail)
                    {
                        data.export_bill_detail.Remove(item);
                    }
                    data.export_bill.Remove(export);
                    return true;                  
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}
