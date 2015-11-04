using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;
using System.Diagnostics;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Manufacturer" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Manufacturer.svc or Manufacturer.svc.cs at the Solution Explorer and start debugging.
    public class Manufacturer : IManufacturer
    {
        public List<manufacturer> GetAllManufacturer()
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_save = (data.manufacturers.Select(p => p)).ToList();
                    return my_save;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public manufacturer GetManufacturerById(int id)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_save = data.manufacturers.First(s => s.id == id);
                    return my_save;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public bool AddManufacturer(manufacturer s)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    data.manufacturers.Add(s);
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

        public bool UpdateManufacturer(manufacturer s)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    //Test
                    var getItem = data.manufacturers.Single(p => p.id == s.id);
                    //data.Entry(s).State = EntityState.Modified;
                    getItem = s;
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

        public manufacturer GetManufacturerByName(string name)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_data = data.manufacturers.AsNoTracking()
                        .Where(m => m.name == name).FirstOrDefault();
                    return my_data;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
    
    }
}
