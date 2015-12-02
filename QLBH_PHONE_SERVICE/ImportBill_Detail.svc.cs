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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ImportBill_Detail" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ImportBill_Detail.svc or ImportBill_Detail.svc.cs at the Solution Explorer and start debugging.
    public class ImportBill_Detail : IImportBill_Detail
    {
        public List<import_bill_detail> GetAllImportBill_Detail()
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var my_data = (data.import_bill_detail.Select(p => p)).ToList();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<import_bill_detail> GetImportBill_DetailByIdProduct(int productId)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var my_data = data.import_bill_detail.AsNoTracking()
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

        public List<import_bill_detail> GetImportBill_DetailByIdImportBill(int importBillId)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var my_data = data.import_bill_detail.AsNoTracking()
                        .Where(s => s.id_import_bill == importBillId).ToList();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public import_bill_detail GetImportBill_DetailByBothId(int productId, int importBillId)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var my_data = data.import_bill_detail.First(s => s.id_product == productId && s.id_import_bill == importBillId);
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
        public bool AddImportBill_Detail(import_bill_detail i)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    data.import_bill_detail.Add(i);
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

        public bool UpdateImportBill_Detail(import_bill_detail i)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {                          
                    data.Entry(i).State = EntityState.Modified;
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



        public bool DeleteImportBill_DetailByIdProduct(int id_product)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var li = data.import_bill_detail.Where(i => i.id_product == id_product).ToList();
                    if (li == null) return true;
                    foreach (var item in li)
                    {
                        data.import_bill_detail.Remove(item);
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

        public bool DeleteImportBill_DetailByIdImportBill(int id_import)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var li = data.import_bill_detail.Where(i => i.id_import_bill == id_import).ToList();
                    if (li == null) return true;
                    foreach (var item in li)
                    {
                        data.import_bill_detail.Remove(item);
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
