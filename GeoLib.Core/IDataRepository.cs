using GeoLib.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Core
{
    public interface IDataRepository<T> : IDataRepository where T : class, IIdentityKey, new()
    {
        T Insert(T entity);
        int Remove(T entity);
        int Remove(int id);
        T Update(T entity);
        IEnumerable<T> SelectAllRecords();
        T SelectRecordByKey(int id);
    }
}
