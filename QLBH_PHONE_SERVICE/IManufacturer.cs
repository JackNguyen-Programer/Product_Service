using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLBH_PHONE_SERVICE.Models;

namespace QLBH_PHONE_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IManufacturer" in both code and config file together.
    [ServiceContract]
    public interface IManufacturer
    {
        [OperationContract]
        List<manufacturer> GetAllManufacturer();
        [OperationContract]
        manufacturer GetManufacturerById(int id);
        [OperationContract]
        manufacturer GetManufacturerByName(string name);
        [OperationContract]
        bool AddManufacturer(manufacturer s);
        [OperationContract]
        bool UpdateManufacturer(manufacturer s);
    }
}
