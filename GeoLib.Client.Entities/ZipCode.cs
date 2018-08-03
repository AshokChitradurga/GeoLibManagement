namespace GeoLib.Client.Entities
{
    using System;
    using GeoLib.Common.Contracts;
    using Utils;
    using System.Collections.Generic;

    public class ZipCode : PropertyChangedBase, IIdentityKey
    {
        private int _ZipCodeId;
        private string _City;
        private int _StateId;
        private string _Zip;
        private string _County;
        private int _AreaCode;
        private int _Fips;
        private string _TimeZone;
        private bool _ObservesDST;
        private double _Latitude;
        private double _Longitude;
        private State _State;

        public int ZipCodeId
        {
            get
            {
                return _ZipCodeId;
            }
            set
            {
                if (value != _ZipCodeId)
                {
                    _ZipCodeId = value;
                    OnPropertyChanged(() => ZipCodeId);
                }
            }
        }
        public string City
        {
            get { return _City; }
            set
            {
                if (value != _City)
                {
                    _City = value;
                    OnPropertyChanged(() => City);
                }
            }
        }
        public int StateId
        {
            get { return _StateId; }
            set
            {
                if (value != _StateId)
                {
                    _StateId = value;
                    OnPropertyChanged(() => StateId);
                }
            }
        }
        public string Zip
        {
            get { return _Zip; }
            set
            {
                if (value != _Zip)
                {
                    _Zip = value;
                    OnPropertyChanged(() => Zip);
                }
            }
        }
        public string County
        {
            get { return _County; }
            set
            {
                if (value != _County)
                {
                    _County = value;
                    OnPropertyChanged(() => County);
                }
            }
        }
        public int AreaCode
        {
            get { return _AreaCode; }
            set
            {
                if (value != _AreaCode)
                {
                    _AreaCode = value;
                    OnPropertyChanged(() => AreaCode);
                }
            }
        }
        public int Fips
        {
            get { return _Fips; }
            set
            {
                if (value != _Fips)
                {
                    _Fips = value;
                    OnPropertyChanged(() => Fips);
                }
            }
        }
        public string TimeZone
        {
            get { return _TimeZone; }
            set
            {
                if (value != _TimeZone)
                {
                    _TimeZone = value;
                    OnPropertyChanged(() => TimeZone);
                }
            }
        }
        public bool ObservesDST
        {
            get { return _ObservesDST; }
            set
            {
                if (value != _ObservesDST)
                {
                    _ObservesDST = value;
                    OnPropertyChanged(() => ObservesDST);
                }
            }
        }
        public double Latitude
        {
            get { return _Latitude; }
            set
            {
                if (value != _Latitude)
                {
                    _Latitude = value;
                    OnPropertyChanged(() => Latitude);
                }
            }
        }
        public double Longitude
        {
            get { return _Longitude; }
            set
            {
                if (value != _Longitude)
                {
                    _Longitude = value;
                    OnPropertyChanged(() => Longitude);
                }
            }
        }
        public State State
        {
            get { return _State; }
            set
            {
                if (value != _State)
                {
                    _State = value;
                    OnPropertyChanged(() => State);
                }
            }
        }

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

    public class Test
    {
        public string Dummy { get; set; }
    }
}
