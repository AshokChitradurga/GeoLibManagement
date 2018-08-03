using GeoLib.Business.Entities;
using GeoLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Data
{
    public interface IZipCodeRepository : IDataRepository<ZipCode>
    {
        ZipCode GetByZip(string zip);
        IEnumerable<ZipCode> GetByState(string state);
        IEnumerable<ZipCode> GetZipByRange(ZipCode zip, int range);
    }
}
