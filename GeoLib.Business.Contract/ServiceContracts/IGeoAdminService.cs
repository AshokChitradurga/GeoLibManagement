using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Business.Contract
{
    [ServiceContract]
    public interface IGeoAdminService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void UpdateState(string oldstate, string newstate);
    }
}
