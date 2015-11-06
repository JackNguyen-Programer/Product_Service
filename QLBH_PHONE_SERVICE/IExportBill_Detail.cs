using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IExportBill_Detail" in both code and config file together.
    [ServiceContract]
    public interface IExportBill_Detail
    {
        [OperationContract]
        List<export_bill_detail> GetAllExportBill_Detail();
        [OperationContract]
        List<export_bill_detail> GetExportBill_DetailByIdProduct(int productId);
        [OperationContract]
        List<export_bill_detail> GetExportBill_DetailByIdExportBill(int exportBillId);
        [OperationContract]
        export_bill_detail GetExportBill_DetailByBothId(int productId, int exportBillId);
        [OperationContract]
        bool AddExportBill_Detail(export_bill_detail eb);
        [OperationContract]
        bool UpdateExportBill_Detail(export_bill_detail eb);
        [OperationContract]
        bool DeleteExportBill_DetailByIdProduct(int id_product);
        [OperationContract]
        bool DeleteExportBill_DetailByIdExportBill(int id_export);
    }
}
