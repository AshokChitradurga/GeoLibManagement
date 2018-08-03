using GeoLib.Business.Entities;
using GeoLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Data
{
    public interface IStateRepository : IDataRepository<State>
    {
        State GetByAbbrivation(string abbrivation);
        IEnumerable<State> GetByPrimaryState(bool isPrimaryState);
    }
}
