using GeoLib.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoLib.Utils;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel.Composition;
using GeoLib.Core;

namespace GeoLib.Data
{
    [Export(typeof(IDataRepositoryFactory))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        T IDataRepositoryFactory.GetDataRepository<T>()
        {
            return RepositoryLoader.Container.GetExportedValue<T>();
        }
    }
}
