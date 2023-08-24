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

            if ( type != null && ids != null && !_LinkedIds.ContainsKey(type))
            {              
                var result = _LinkedIds.TryAdd(type, ids);
            }
        }
        protected ALinkedById(){}

        protected ALinkedById(int id) => Id = id;
        public int Id {get ;}

        private int? _LinkedId;
        public int? LinkedId
        {
            get
            {
                if (_LinkedIds != null && _LinkedId == null && _LinkedIds.TryGetValue(GetType(), out var dct))
                    if (dct != null && dct.TryGetValue(Id, out var newId))
                    {
                        _LinkedId = newId;
                    }
                return _LinkedId;
            }
        }
        public bool LinkedFlag { get => LinkedId.HasValue; }
    }
}
