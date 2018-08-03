using GeoLib.Business.Contract;
using GeoLib.Business.Entities;
using GeoLib.Common.Contracts;
using GeoLib.Core;
using GeoLib.Data;
using GeoLib.Utils;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeoLib.Business.Manager
{
    public class GeoZipCodeManager : IGeoService, IGeoAdminService
    {
        IStateRepository _stateRepository = default(IStateRepository);
        IZipCodeRepository _zipCodeRepository = default(IZipCodeRepository);
        IDataRepositoryFactory _DataRepositoryFactory = default(IDataRepositoryFactory);

        public GeoZipCodeManager()
        {
            //ServiceLocator.SetLocatorProvider(() => new RepositoryLocatorProvider());
            //_DataRepositoryFactory = ServiceLocator.Current.GetInstance<IDataRepositoryFactory>();
            //_stateRepository = _DataRepositoryFactory.GetDataRepository<IStateRepository>();
            //_zipCodeRepository = _DataRepositoryFactory.GetDataRepository<IZipCodeRepository>();
        }
        public GeoZipCodeManager(IZipCodeRepository zipCodeRepository)
        {
            _zipCodeRepository = zipCodeRepository;
        }
        public GeoZipCodeManager(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public IEnumerable<string> GetStates(bool isPrimaryOnly)
        {
            List<string> stateData = new List<string>();
            var states = _stateRepository.GetByPrimaryState(isPrimaryOnly);
            foreach (var state in states)
                stateData.Add(state.Abbreviation);
            return stateData;
        }
        public ZipCode GetZipInfo(string zip)
        {
            Console.WriteLine("Service Operation <{0}> entered", MethodBase.GetCurrentMethod().Name);
            string hostIdentity = WindowsIdentity.GetCurrent() != null
                ? WindowsIdentity.GetCurrent().Name : string.Empty;
            Console.WriteLine("HostIdentity =", hostIdentity);

            string primaryIdentity = ServiceSecurityContext.Current != null
                    ? ServiceSecurityContext.Current.PrimaryIdentity.Name
                    : string.Empty;
            Console.WriteLine("primaryIdentity =", primaryIdentity);
            string windowsIdentity = ServiceSecurityContext.Current != null
                    ? ServiceSecurityContext.Current.WindowsIdentity.Name
                    : string.Empty;
            //  string threadIndentity = Thread.CurrentPrincipal.Identity.Name;

            var output = _zipCodeRepository.GetByZip(zip);
            //  output.TestData = new List<Test>() { new Test() { Dummy = "Kill" } };

            if (output != null)
            {
                Console.WriteLine(output.State.Name);
                Console.WriteLine(output.City);
            }
            return output;
        }
        public IEnumerable<ZipCode> GetZips(string state)
        {
            Console.WriteLine("Service Operation <{0}> entered", MethodBase.GetCurrentMethod().Name);
            return _zipCodeRepository.GetByState(state).ToList();
        }
        public IEnumerable<ZipCode> GetZips(ZipCode zipCode, int range)
        {
            return _zipCodeRepository.GetZipByRange(zipCode, range);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        //[PrincipalPermission(SecurityAction.Demand, Role ="Administrators")]
        public void UpdateState(string oldState, string newState)
        {
            string hostIdentity = WindowsIdentity.GetCurrent().Name;
            string primaryIdentity = ServiceSecurityContext.Current.PrimaryIdentity.Name;
            string windowsIdentity = ServiceSecurityContext.Current.WindowsIdentity.Name;
            string threadIdentity = Thread.CurrentPrincipal.Identity.Name;
            Console.WriteLine(hostIdentity);
            Console.WriteLine("Primary", primaryIdentity);
            Console.WriteLine("Windows", windowsIdentity);
            Console.WriteLine("Thread", threadIdentity);
            var state = _stateRepository.GetByAbbrivation(oldState);
            if (state != null)
                state.Abbreviation = newState;
            Console.WriteLine("New state abbrivation" + state.Abbreviation);
            _stateRepository.Update(state);
        }

        private class PriciplePermissionAttribute : Attribute
        {
        }
    }
}
