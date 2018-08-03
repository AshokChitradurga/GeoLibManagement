using GeoLib.Client.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GeoLib.Client.Entities;
using GeoLib.Core;

namespace GeoLib.Client.Proxies
{
    //  : ClientBase<IGeoService>, IGeoService
    public class GeoClient 
    {
        public IEnumerable<string> GetStates(bool isPrimaryOnly)
        {
            IEnumerable<string> lstGeoStates = default(IEnumerable<string>);
            using (ChannelFactory<IGeoService> oGeoService = new ChannelFactory<IGeoService>(""))
            {
                IGeoService oService = oGeoService.CreateChannel();
                lstGeoStates = oService.GetStates(isPrimaryOnly);
            }
            return lstGeoStates;
            //  return Channel.GetStates(isPrimaryOnly);
        }
        public ZipCode GetZipInfo(string zip)
        {
            using (ChannelFactory<IGeoService> oGeoService = new ChannelFactory<IGeoService>(""))
            {
                IGeoService oService = oGeoService.CreateChannel();
                return oService.GetZipInfo(zip);
            }
           // return Channel.GetZipInfo(zip);
        }
        public IEnumerable<ZipCode> GetZips(string state)
        {
            using (ChannelFactory<IGeoService> oGeoService = new ChannelFactory<IGeoService>(""))
            {
                IGeoService oService = oGeoService.CreateChannel();
                return oService.GetZips(state);
            }
            //  return Channel.GetZips(state);
        }
        public IEnumerable<ZipCode> GetZips(ZipCode zipCode, int range)
        {
            using (ChannelFactory<IGeoService> oGeoService = new ChannelFactory<IGeoService>(""))
            {
                IGeoService oService = oGeoService.CreateChannel();
                return oService.GetZips(zipCode, range);
            }
            //  return Channel.GetZips(zipCode, range);
        }

        //public void UpdateState(string oldState, string newState)
        //{
        //    using (ChannelFactory<IGeoAdminService> oGeoService = new ChannelFactory<IGeoAdminService>(""))
        //    {
        //        IGeoAdminService oService = oGeoService.CreateChannel();
        //        oService.UpdateState(oldState, newState);
        //    }
        //}
    }
}
