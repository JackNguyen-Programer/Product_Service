using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;


namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISave" in both code and config file together.
    [ServiceContract]
    public interface ISave
    {
        [OperationContract]
        List<save> GetAllSave();
        [OperationContract]
        save GetSaveWithId(int id);
        [OperationContract]
        bool AddSave(save s);
        [OperationContract]
        bool UpdateSave(save s);
    }
}
