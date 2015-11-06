using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IExportBill" in both code and config file together.
    [ServiceContract]
    public interface IExportBill
    {
        [OperationContract]
        List<export_bill> GetAllExportBill();
        [OperationContract]
        export_bill GetExportBillById(int id);
        [OperationContract]
        List<export_bill> GetExportBillByEmail(string email);
        [OperationContract]
        List<export_bill> GetExportBillByDateFromTo(DateTime from, DateTime to);
        
        [OperationContract]
        List<export_bill> GetExportBillByEmailAndDateFromTo(string email, DateTime from, DateTime to);
        [OperationContract]
        export_bill GetLastExportBill();
        [OperationContract]
        bool AddExportBill(export_bill eb);
        [OperationContract]
        bool UpdateExportBill(export_bill eb);
        [OperationContract]
        bool DeleteExportBillByIdUser(int idUser);
        [OperationContract]
        bool DeleteExportBillById(int id);
    }
}
