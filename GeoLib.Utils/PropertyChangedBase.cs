using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Utils
{
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        private event PropertyChangedEventHandler _PropertyChangedEvent;
        protected List<PropertyChangedEventHandler> _PropertyChangedSubscribers = new List<PropertyChangedEventHandler>();

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if (!_PropertyChangedSubscribers.Contains(value))
                {
                    _PropertyChangedEvent += value;
                    _PropertyChangedSubscribers.Add(value);
                }
            }
            remove
            {
                _PropertyChangedEvent -= value;
                _PropertyChangedSubscribers.Remove(value);
            }
        }

        private void OnPropertyChanged(string propName)
        {
            //  if (_PropertyChangedEvent != null)
            _PropertyChangedEvent?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> predicate)
        {
            string propName = PropertySupport.ExtractPropertyName<T>(predicate);
            OnPropertyChanged(propName);
        }
    }
}
