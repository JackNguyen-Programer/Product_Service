using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Save" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Save.svc or Save.svc.cs at the Solution Explorer and start debugging.
    public class Save : ISave
    {
        public List<save> GetAllSave()
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_save = (data.saves.Select(p => p)).ToList();
                    return my_save;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public save GetSaveWithId(int id)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    var my_save = data.saves.First(s => s.id == id);
                    return my_save;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public bool AddSave(save s)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    data.saves.Add(s);
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

        public bool UpdateSave(save s)
        {
            try
            {
                using (QLBH_PHONE_Entities data = new QLBH_PHONE_Entities())
                {
                    //Test
                    var getItem = data.saves.Single(p => p.id == s.id);
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
    }
}
