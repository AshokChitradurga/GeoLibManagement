namespace GeoLib.Client.Entities
{
    using GeoLib.Common.Contracts;
    using Utils;

    public class State : PropertyChangedBase, IIdentityKey
    {
        private int _stateId;
        private string _abbreviation;
        private string _name;
        private bool _isPrimaryState;

        public int StateId
        {
            get
            {
                return _stateId;
            }
            set
            {
                if(value != _stateId)
                {
                    _stateId = value;
                    OnPropertyChanged(() => StateId);
                }
            }
        }
        public string Abbreviation
        {
            get
            {
                return _abbreviation;
            }
            set
            {
                if(value != _abbreviation)
                {
                    _abbreviation = value;
                    OnPropertyChanged(() => Abbreviation);
                }
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }
        public bool IsPrimaryState
        {
            get
            {
                return _isPrimaryState;
            }
            set
            {
                if (value != _isPrimaryState)
                {
                    _isPrimaryState = value;
                    OnPropertyChanged(() => IsPrimaryState);
                }
            }
        }

        public int EntityId
        {
            get
            {
                return StateId;
            }

            set
            {
                StateId = value;
            }
        }
    }
}
