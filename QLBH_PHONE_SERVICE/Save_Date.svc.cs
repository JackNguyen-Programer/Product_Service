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
    public class Save_Date : ISave_Date
    {
        public List<Models.save_date> GetAllSaveDate()
        {
            try
            {
                using (QLBH_PHONE_Entity data = new QLBH_PHONE_Entity())
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
                using (QLBH_PHONE_Entity data = new QLBH_PHONE_Entity())
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
                using (QLBH_PHONE_Entity data = new QLBH_PHONE_Entity())
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
                using (QLBH_PHONE_Entity data = new QLBH_PHONE_Entity())
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
                using (QLBH_PHONE_Entity data = new QLBH_PHONE_Entity())
                {
                    //Test
                    var getItem = data.save_date.Single(p => p.id == s.id);
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
