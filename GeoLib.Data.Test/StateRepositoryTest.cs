using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition.Hosting;
using Microsoft.Practices.ServiceLocation;
using GeoLib.Core;
using System.Reflection;
using System.Collections.Generic;

namespace GeoLib.Data.Test
{
    [TestClass]
    public class StateRepositoryTest
    {
        StateRepository _stateRepository = default(StateRepository);
        ZipCodeRepository _zipCodeRepository = default(ZipCodeRepository);

        public StateRepositoryTest()
        {
            ServiceLocator.SetLocatorProvider(() => new RepositoryLocatorProvider());
            _stateRepository = ServiceLocator.Current.GetInstance<IStateRepository>() as StateRepository;
            _zipCodeRepository = ServiceLocator.Current.GetInstance<IZipCodeRepository>() as ZipCodeRepository;
        }

        [TestMethod]
        public void test_insert_for_state()
        {
            _stateRepository.Insert(
                new Business.Entities.State
                { Abbreviation = "SL", Name = "SriLanka", IsPrimaryState = true });
        }

        [TestMethod]
        public void test_update_for_statebyid()
        {
            var beforeUpdate = _stateRepository.SelectRecordByKey(188);
            beforeUpdate.IsPrimaryState = false;
            var afterUpdate = _stateRepository.Update(beforeUpdate);
            Assert.AreNotSame(afterUpdate.IsPrimaryState, beforeUpdate.IsPrimaryState, "Both are not same");
        }

        [TestMethod]
        public void test_update_for_statebyabbrivation()
        {
            var beforeUpdate = _stateRepository.GetByAbbrivation("IND");
            beforeUpdate.Name = "Karnataka";
            beforeUpdate.Abbreviation = "KAR";
            var afterUpdate = _stateRepository.Update(beforeUpdate);
            Assert.AreNotSame(afterUpdate.IsPrimaryState, beforeUpdate.IsPrimaryState, "Both are not same");
        }
    }
}
