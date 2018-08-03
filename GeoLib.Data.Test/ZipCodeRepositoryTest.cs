using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoLib.Core;
using GeoLib.Business.Entities;

namespace GeoLib.Data.Test
{
    [TestClass]
    public class ZipCodeRepositoryTest
    {
        [TestMethod]
        public void test_zipcode_by_state()
        {
            var _zipCodeRepository = new ZipCodeRepository();
            RepositoryLoader.Init<ZipCodeRepository>(_zipCodeRepository);
            var states = _zipCodeRepository.GetByState("India");
        }

        [TestMethod]
        public void test_zipcode_insert()
        {
            var _zipCodeRepository = new ZipCodeRepository();
            RepositoryLoader.Init<ZipCodeRepository>(_zipCodeRepository);
            _zipCodeRepository.Insert(new ZipCode
            {
                City = "Delhi",
                StateId = 187,
                Zip = "9101",
                County = "Delhi",
                AreaCode = 01,
                Fips = 18095,
                TimeZone = "IST",
                ObservesDST = false,
                Latitude = 40.2561,
                Longitude = -85.6514
            });
        }

        [TestMethod]
        public void test_zipcode_get()
        {
            var _zipCodeRepository = new ZipCodeRepository();
            RepositoryLoader.Init<ZipCodeRepository>(_zipCodeRepository);
            var output = _zipCodeRepository.GetByZip("00501");
        }
    }
}
