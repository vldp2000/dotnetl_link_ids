using System.Collections;
using System.Collections.Concurrent;

namespace JWTTestWebApi.Services.ServiceHelper
{
    public class ObjectPropertyFromDictionarySubstituter
    {
        private static ObjectPropertyFromDictionarySubstituter _instrance;

        private ObjectPropertyFromDictionarySubstituter()
        {
        }

        public static ObjectPropertyFromDictionarySubstituter GetInstanse()
        {
            if (_instrance == null)
                _instrance = new ObjectPropertyFromDictionarySubstituter();
            return _instrance;
        }

        public static Int32? SubstituteIntPropertyValueUsingProvidedDictionary(Object obj, string propertyName, Dictionary<int, int> dict)
        {
            int? result = null;
            var property = obj.GetType().GetProperty(propertyName);
            if (property != null && property.PropertyType == typeof(Int32) && dict != null)
            {
                var propertyValue = property.GetValue(obj, null);

                if (propertyValue is int value && propertyValue != null)
                {
                    if (dict.TryGetValue(value, out var newValue))
                        result = newValue;
                    property.SetValue(obj, newValue, null);
                }
            }
            return result;
        }

        public static string? SubstituteStringPropertyValueUsingProvidedDictionary(Object obj, string propertyName, Dictionary<string, string> dict)
        {
            string? result = null;
            var property = obj.GetType().GetProperty(propertyName);
            if (property != null && property.PropertyType == typeof(string) && dict != null)
            {
                var propertyValue = property.GetValue(obj, null);

                if (propertyValue is string value && propertyValue != null)
                {
                    if (dict.TryGetValue(value, out var newValue))
                        result = newValue;
                    property.SetValue(obj, newValue, null);
                }
            }
            return result;
        }

    }
}
