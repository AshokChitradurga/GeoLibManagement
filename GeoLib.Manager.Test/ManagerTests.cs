using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GeoLib.Data;
using GeoLib.Business.Entities;
using GeoLib.Business.Contract;
using GeoLib.Business.Manager;

namespace GeoLib.Manager.Test
{
    [TestClass]
    public class ManagerTests
    {
        [TestMethod]
        public void test_zipcode_retrieval()
        {
            Mock<IZipCodeRepository> mockZipCodeRepository = new Mock<IZipCodeRepository>();
            ZipCode zipdata = new ZipCode()
            {
                City = "Test",
                State = new State() { Abbreviation = "KAR" },
                Zip = "07345"
            };
            mockZipCodeRepository.Setup(obj => obj.GetByZip("07345")).Returns(zipdata);
            IGeoService oGeoService = new GeoZipCodeManager(mockZipCodeRepository.Object);
            var zipcodeoutput = oGeoService.GetZipInfo("07345");
            Assert.IsTrue(zipcodeoutput.City.ToUpper() == "Test".ToUpper());
            Assert.IsTrue(zipcodeoutput.State.Abbreviation.ToUpper() == "KAR");
        }

        [TestMethod]
        public void test_zipcode_update()
        {
            Mock<IStateRepository> mockStateRepository = new Mock<IStateRepository>();
            State _state = new State()
            {
                Abbreviation = "ABR",
                IsPrimaryState = false,
                Name = "Abrimomn",
                StateId = 36
            };
            mockStateRepository.Setup(obj => obj.GetByAbbrivation("ABR")).Returns(_state);
            IGeoAdminService oGeoService = new GeoZipCodeManager(mockStateRepository.Object);
            oGeoService.UpdateState("KAR", "ABR");
            //  Assert.IsTrue(zipcodeoutput.City.ToUpper() == "Test".ToUpper());
        }
    }

}
