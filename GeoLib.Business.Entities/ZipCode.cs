namespace GeoLib.Business.Entities
{
    using System;
    using GeoLib.Common.Contracts;
    using System.Collections;
    using System.Collections.Generic;

    public class ZipCode : IIdentityKey
    {
        public int ZipCodeId { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string Zip { get; set; }
        public string County { get; set; }
        public int AreaCode { get; set; }
        public int Fips { get; set; }
        public string TimeZone { get; set; }
        public bool ObservesDST { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public State State { get; set; }
        public int EntityId
        {
            get
            {
                return ZipCodeId;
            }

            set
            {
                ZipCodeId = value;
            }
        }
    }
}
