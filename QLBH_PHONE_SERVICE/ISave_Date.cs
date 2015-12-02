using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISave_Date" in both code and config file together.
    [ServiceContract]
    public interface ISave_Date
    {
        [OperationContract]
        List<save_date> GetAllSaveDate();
        [OperationContract]
        save_date GetSaveDateWithId(int id);
        [OperationContract]
        List<save_date> GetSaveDateWithIdSave(int id_save);
        [OperationContract]
        bool AddSaveDate(save_date s);
        [OperationContract]
        bool UpdateSaveDate(save_date s);
        [OperationContract]
        bool DeleteSaveDate(int id);
    }
}
