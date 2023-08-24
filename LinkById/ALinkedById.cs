using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LinkById
{
    public abstract class ALinkedById : ILinkedById
    {
        private static IDictionary<Type, IDictionary<int, int>>? _LinkedIds = null;

        public static void AddLinkedIdList(Type type, IDictionary<int, int> ids)
        {           
            if (_LinkedIds == null)
                _LinkedIds = new Dictionary<Type, IDictionary<int, int>>();

            if (type != null && ids != null && !_LinkedIds.ContainsKey(type))
            {
                _LinkedIds.Add(type, ids);
            }
        }

        public static void CleanLinkedValues()
        {
            if (_LinkedIds != null)
            {
                _LinkedIds.Clear();
                _LinkedIds = null;
            }
        }

        protected ALinkedById(){}

        public virtual int PropertyToBeLinked {get ;}

        private int? _LinkedId;
        public virtual int? LinkedValue
        {
            get
            {
                if (_LinkedIds != null && _LinkedId == null && _LinkedIds.TryGetValue(GetType(), out var dct))
                    if (dct != null && dct.TryGetValue(PropertyToBeLinked, out var newId))
                    {
                        _LinkedId = newId;
                    }
                return _LinkedId;
            }
        }
        public bool LinkedFlag { get => LinkedValue.HasValue; }

    }
}
