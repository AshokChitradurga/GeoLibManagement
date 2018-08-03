using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Common.Contracts
{
    public interface IIdentityKey
    {
        int EntityId { get; set; }
    }
}

