namespace GeoLib.Core
{
    using System.Linq;

    public class SimpleMapper
    {
        private static SimpleMapper _instance;

        private SimpleMapper()
        {
        }

        public static SimpleMapper Instance()
        {
            if (null == _instance) _instance = new SimpleMapper();
            return _instance;
        }
        public void PropertyMapper<uT, sT>(sT oSource, uT oUpdated)
        {
            var _sourceProperties = oSource.GetType().GetProperties();
            var _destinationProperties = oUpdated.GetType().GetProperties();
            foreach (var prp in _sourceProperties)
            {
                var dProperty = _destinationProperties.Where(prop => prop.Name == prp.Name).SingleOrDefault();
                if (null != dProperty)
                {
                    dProperty.SetValue(oSource, prp.GetValue(oUpdated, null), null);
                }
            }
        }
    }
}
