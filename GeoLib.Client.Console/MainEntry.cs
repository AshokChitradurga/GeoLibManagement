using GeoLib.Client.Entities;
using GeoLib.Client.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Client.Console
{
    class MainEntry
    {
        static void Main(string[] args)
        {
            System.Console.Write("Enter Zip code:");
            var zip = System.Console.ReadLine();
            System.Console.Write("Enter old state abbrivation:");
            var oldstate = System.Console.ReadLine();
            System.Console.Write("Enter new state abbrivation:");
            var newstate = System.Console.ReadLine();

            GeoClient proxy = new GeoClient();

            try
            {
                var result = proxy.GetStates(true);
                var zipsByState = proxy.GetZips(new ZipCode() { County = "India" }, 1);

                var zipcodeByInfo = proxy.GetZipInfo(zip);

                GeoAdminClient adminClient = new GeoAdminClient();
                adminClient.ClientCredentials.UserName.UserName = "TestUser-1";
                adminClient.ClientCredentials.UserName.Password = "test@123";

                adminClient.UpdateState(oldstate, newstate);
                //  var allZipCodes = proxy.GetZips(new ZipCode() { }, 1);
                System.Console.Write("State:");
                System.Console.WriteLine(null != zipcodeByInfo.State ? zipcodeByInfo.State.Name : string.Empty);
                System.Console.Write("City:");
                System.Console.WriteLine(null != zipcodeByInfo.City ? zipcodeByInfo.City : string.Empty);
            }
            finally
            {
                //  proxy.Close();
            }

            System.Console.ReadLine();
        }
    }
}
