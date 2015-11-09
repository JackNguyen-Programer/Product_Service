using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;
using System.Diagnostics;
using System.Data.Entity;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ExportBill_Detail" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ExportBill_Detail.svc or ExportBill_Detail.svc.cs at the Solution Explorer and start debugging.
    public class ExportBill_Detail : IExportBill_Detail
    {
        public List<export_bill_detail> GetAllExportBill_Detail()
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_data = (data.export_bill_detail.Select(p => p)).ToList();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<export_bill_detail> GetExportBill_DetailByIdProduct(int productId)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_data = data.export_bill_detail.AsNoTracking()
                        .Where(s => s.id_product == productId).ToList();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<export_bill_detail> GetExportBill_DetailByIdExportBill(int exportBillId)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_data = data.export_bill_detail.AsNoTracking()
                        .Where(s => s.id_export_bill == exportBillId).ToList();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public export_bill_detail GetExportBill_DetailByBothId(int productId, int exportBillId)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_data = data.export_bill_detail.First(s => s.id_product == productId && s.id_export_bill == exportBillId);
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public bool AddExportBill_Detail(export_bill_detail eb)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    data.export_bill_detail.Add(eb);
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

        public bool UpdateExportBill_Detail(export_bill_detail eb)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {                                 
                    data.Entry(eb).State = EntityState.Modified;                    
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


        public bool DeleteExportBill_DetailByIdProduct(int id_product)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    //List<export_bill_detail> le = GetExportBill_DetailByIdProduct(id_product).ToList();
                    var le = data.export_bill_detail.Where(e => e.id_product == id_product).ToList();
                    if (le == null) return true;
                    foreach (var item in le)
                    {
                        data.export_bill_detail.Remove(item);
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

        public bool DeleteExportBill_DetailByIdExportBill(int id_export)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    //var le = GetExportBill_DetailByIdExportBill(id_export).ToList();
                    var le = data.export_bill_detail.Where(e => e.id_export_bill == id_export).ToList();
                    if (le == null) return true;
                    foreach (var item in le)
                    {
                        data.export_bill_detail.Remove(item);
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
    }
}
