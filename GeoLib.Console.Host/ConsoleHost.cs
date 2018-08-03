using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GeoLib.Business.Manager;

namespace GeoLib.Console.Host
{
    class ConsoleHost
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost hostGeoManager = new ServiceHost(typeof(GeoZipCodeManager));
                //var address = @"net.tcp://localhost:8080/GeoService";
                //var tcpBinding = new NetTcpBinding();
                //var contract = typeof(GeoLib.Business.Contract.IGeoService);
                //hostGeoManager.AddServiceEndpoint(contract, tcpBinding, address);
                hostGeoManager.Open();
                System.Console.WriteLine("Service is running. Presss <Enter> to exit");
                System.Console.ReadLine();
                hostGeoManager.Close();
            }
            catch(Exception ex)
            {

            }
        }
    }
}

