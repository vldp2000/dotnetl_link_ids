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
        private static Dictionary<Type, Dictionary<int, int>>? _LinkedIds => new Dictionary<Type, Dictionary<int, int>>();

        public static void AddLinkedIdList(Type type, Dictionary<int, int> ids)
        {
            if ( type != null && _LinkedIds != null && !_LinkedIds.ContainsKey(type))
            {
                _LinkedIds.TryAdd(type, ids);
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
