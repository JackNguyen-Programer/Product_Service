using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IImportBill_Detail" in both code and config file together.
    [ServiceContract]
    public interface IImportBill_Detail
    {
        [OperationContract]
        List<import_bill_detail> GetAllImportBill_Detail();
        [OperationContract]
        List<import_bill_detail> GetImportBill_DetailByIdProduct(int productId);
        [OperationContract]
        List<import_bill_detail> GetImportBill_DetailByIdImportBill(int importBillId);
        [OperationContract]
        import_bill_detail GetImportBill_DetailByBothId(int productId, int importBillId);
        [OperationContract]
        bool AddImportBill_Detail(import_bill_detail i);
        [OperationContract]
        bool UpdateImportBill_Detail(import_bill_detail i);
        [OperationContract]
        bool DeleteImportBill_DetailByIdProduct(int id_product);
        [OperationContract]
        bool DeleteImportBill_DetailByIdImportBill(int id_import);
    }
}
