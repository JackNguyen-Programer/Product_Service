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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ImportBill" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ImportBill.svc or ImportBill.svc.cs at the Solution Explorer and start debugging.
    public class ImportBill : IImportBill
    {
        public List<import_bill> GetAllImportBill()
        {
            try
            {
                using (QLBH_PHONE_Entity data = new QLBH_PHONE_Entity())
                {
                    var my_data = (data.import_bill.Select(p => p)).ToList();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public import_bill GetImportBillById(int id)
        {
            try
            {
                using (QLBH_PHONE_Entity data = new QLBH_PHONE_Entity())
                {
                    var my_data = data.import_bill.First(s => s.id == id);
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public bool AddImportBill(import_bill ib)
        {
            try
            {
                using (QLBH_PHONE_Entity data = new QLBH_PHONE_Entity())
                {
                    data.import_bill.Add(ib);
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

        public bool UpdateImportBill(import_bill ib)
        {
            try
            {
                using (QLBH_PHONE_Entity data = new QLBH_PHONE_Entity())
                {                     
                    data.Entry(ib).State = EntityState.Modified;                  
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


        public List<import_bill> GetImportBillFromTo(DateTime from, DateTime to)
        {
            try
            {
                using (QLBH_PHONE_Entity data = new QLBH_PHONE_Entity())
                {
                    var my_data = data.import_bill.AsNoTracking()
                        .Where(i => i.date >= from && i.date <= to).ToList();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<import_bill> GetImportBillByIdManu(int idManu)
        {
            try
            {
                using (QLBH_PHONE_Entity data = new QLBH_PHONE_Entity())
                {
                    var my_data = data.import_bill.AsNoTracking().Where(i => i.id_manufacturer == idManu).ToList();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }


        public bool DeleteImportBill(int id)
        {
            try
            {
                using (QLBH_PHONE_Entity data = new QLBH_PHONE_Entity())
                {
                    var my_data = data.import_bill.Single(i => i.id == id);
                    var importDetail = data.import_bill_detail.Where(i => i.id_import_bill == id).ToList();
                    foreach (var item in importDetail)
                    {
                        data.import_bill_detail.Remove(item);
                    }
                    data.import_bill.Remove(my_data);
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
    }
}
