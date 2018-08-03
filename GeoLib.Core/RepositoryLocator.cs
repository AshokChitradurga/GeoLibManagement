using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;

namespace GeoLib.Core
{
    public class RepositoryLocatorProvider : IServiceLocator
    {
        public RepositoryLocatorProvider()
        {
            RepositoryLoader.Initialize();
        }
        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return RepositoryLoader.Container.GetExportedValues<TService>();
        }
        public object GetInstance(Type serviceType)
        {
            return null;
        }
        public object GetInstance(Type serviceType, string key)
        {
            return null;
        }
        public TService GetInstance<TService>()
        {
            return RepositoryLoader.Container.GetExportedValue<TService>();
        }
        public TService GetInstance<TService>(string key)
        {
            return RepositoryLoader.Container.GetExportedValue<TService>(key);
        }
        public object GetService(Type serviceType)
        {
            return null;
        }
    }
}
