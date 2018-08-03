using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition.Hosting;

namespace GeoLib.Core
{
    public static class RepositoryLoader
    {
        public static CompositionContainer Container;
        public static CompositionContainer Init<T>(T assembly)
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(assembly.GetType().Assembly));
            CompositionContainer container = new CompositionContainer(catalog);
            return container;
        }
        public static void Initialize()
        {
            try
            {
                AggregateCatalog _catalog;
                _catalog = new AggregateCatalog();
                _catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
                _catalog.Catalogs.Add(new DirectoryCatalog(@"."));
                string dir;
                dir = @"bin\";
                if (System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + dir))
                {
                    _catalog.Catalogs.Add(new DirectoryCatalog(dir));
                }
                Container = new CompositionContainer(_catalog);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //var _catalog = new AggregateCatalog();
            //string assname = Assembly.GetExecutingAssembly().FullName;
            //string assLocation = Assembly.GetExecutingAssembly().Location;

            //_catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            //_catalog.Catalogs.Add(new DirectoryCatalog(@"."));
            //  Container = new CompositionContainer(_catalog, true);
        }
    }
}
