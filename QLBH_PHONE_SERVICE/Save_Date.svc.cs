using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Save_Date" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Save_Date.svc or Save_Date.svc.cs at the Solution Explorer and start debugging.
    public class Save_Date : ISave_Date
    {
        public List<Models.save_date> GetAllSaveDate()
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var my_save = (data.save_date.Select(p => p)).ToList();
                    return my_save;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public Models.save_date GetSaveDateWithId(int id)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var my_save = data.save_date.First(s => s.id == id);
                    return my_save;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public List<save_date> GetSaveDateWithIdSave(int id_save)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var my_save = data.save_date.Where(s => s.id_save == id_save).ToList();
                    return my_save;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public bool AddSaveDate(Models.save_date s)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    data.save_date.Add(s);
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

        public bool UpdateSaveDate(Models.save_date s)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var saveDate = data.save_date.Single(p => p.id == s.id);
                    saveDate.id = s.id;
                    saveDate.date_start = s.date_start;
                    saveDate.date_end = s.date_end;
                    saveDate.id_save = s.id_save;
                    saveDate.content = s.content;
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


        public bool DeleteSaveDate(int id)
        {
            try
            {
                using (QLBH_PHONE_ENTITY data = new QLBH_PHONE_ENTITY())
                {
                    var savedate = data.save_date.Single(s => s.id == id);
                    data.save_date.Remove(savedate);
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
