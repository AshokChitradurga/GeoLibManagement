using GeoLib.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Business.Contract
{
    [ServiceContract]
    public interface IGeoService
    {
        [OperationContract]
        ZipCode GetZipInfo(string zip);
        [OperationContract]
        IEnumerable<string> GetStates(bool isPrimaryOnly);
        [OperationContract(Name ="GetZipByState")]
        IEnumerable<ZipCode> GetZips(string state);
        [OperationContract(Name ="GetZipsForRange")]
        IEnumerable<ZipCode> GetZips(ZipCode zipCode, int range);
    }
}
