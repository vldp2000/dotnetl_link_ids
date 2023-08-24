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
        //private static IDictionary<Type, IDictionary<int, int>>? _LinkedIds = null;
        private static Lazy <IDictionary<Type, IDictionary<int, int>>> _lazyLinkedIds = new(() => new Dictionary<Type, IDictionary<int, int>>());
        private static IDictionary<Type, IDictionary<int, int>>? _LinkedIds => Getlazy();

        private static IDictionary<Type, IDictionary<int, int>> Getlazy()
        {
            return _lazyLinkedIds.Value;
        }

        public static void AddLinkedIdList(Type type, IDictionary<int, int> ids)
        {
            //if (_LinkedIds == null)
            //    _LinkedIds = new Dictionary<Type, IDictionary<int, int>>();

            if (type != null && ids != null && !_LinkedIds.ContainsKey(type))
            {
                _LinkedIds.Add(type, ids);
            }
        }


        protected ALinkedById(){}

        protected ALinkedById(int id) => OriginalValue = id;
        public virtual int OriginalValue {get ;}

        private int? _LinkedId;
        public virtual int? LinkedValue
        {
            get
            {
                if (_LinkedIds != null && _LinkedId == null && _LinkedIds.TryGetValue(GetType(), out var dct))
                    if (dct != null && dct.TryGetValue(OriginalValue, out var newId))
                    {
                        _LinkedId = newId;
                    }
                return _LinkedId;
            }
        }
        public bool LinkedFlag { get => LinkedValue.HasValue; }
    }
}
