using GeoLib.Client.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Client.Proxies
{
    public class GeoAdminClient : ClientBase<IGeoAdminService>, IGeoAdminService
    {
        public void UpdateState(string oldstate, string newstate)
        {
            Channel.UpdateState(oldstate, newstate);
        }
    }
}
