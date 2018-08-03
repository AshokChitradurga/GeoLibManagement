using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Client.Contract
{
    [ServiceContract]
    public interface IGeoAdminService
    {
        [OperationContract]
        void UpdateState(string oldstate, string newstate);
    }
}
