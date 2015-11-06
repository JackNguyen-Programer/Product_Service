using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IImportBill" in both code and config file together.
    [ServiceContract]
    public interface IImportBill
    {
        [OperationContract]
        List<import_bill> GetAllImportBill();
        [OperationContract]
        import_bill GetImportBillById(int id);
        [OperationContract]
        List<import_bill> GetImportBillFromTo(DateTime from, DateTime to);
        [OperationContract]
        List<import_bill> GetImportBillByIdManu(int idManu);
        [OperationContract]
        bool AddImportBill(import_bill ib);
        [OperationContract]
        bool UpdateImportBill(import_bill ib);
        [OperationContract]
        bool DeleteImportBill(int id);
    }
}
