using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkById
{
    public static class MyExtensions
    {
        public static int? FindSubstituteValue(this ISubstitute self, string propertyName, Dictionary<int , int> dict) 
        {
            int? result = null;
            var property = self.GetType().GetProperty(propertyName);
            if (property != null && dict != null)
            {
                var propertyValue = property.GetValue(self, null);

                if ( propertyValue is int value && propertyValue != null)
                {
                    if (dict.TryGetValue(value , out var newId))
                        return newId;
                }

            }
            return result;
        }
    }
}
