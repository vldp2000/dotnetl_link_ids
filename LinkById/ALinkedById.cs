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
        private static Dictionary<Type, Dictionary<int, int>> _LinkedIds = new Dictionary<Type, Dictionary<int, int>>();

        protected ALinkedById()
        {

        }

        protected ALinkedById(int id)
        {
            Id = id;
        }

        protected ALinkedById(Dictionary<int, int> ids)
        {
            var dct = _LinkedIds.FirstOrDefault(obj => obj.Key == GetType()).Value;
            if (dct == null)
                _LinkedIds.Add(GetType(), ids);
        }

        public int Id {get ;}

        private int? _LinkedId;
        public int? LinkedId 
        { 
            get {
                if (_LinkedIds != null && _LinkedId == null)
                {
                    var dct = _LinkedIds.Where(item => item.Key == GetType()).FirstOrDefault().Value;
                    int? newId = (int?)dct.Where(item => item.Key == Id).FirstOrDefault().Value;
                    if (newId.HasValue)
                    {
                        _LinkedId = newId;
                    }
                }
                return _LinkedId; 
            }
        }
        public bool LinkedFlag { get => LinkedId.HasValue; }
        public Dictionary<int, int>? LinkedIds
        {
            get
            {
                var dct = _LinkedIds.Where(item => item.Key == GetType()).FirstOrDefault().Value;
                if (dct != null)
                    return dct;
                else
                    return null;
            }
            set
            {
                if (value != null)
                {
                    var dct = _LinkedIds.Where(item => item.Key == GetType()).FirstOrDefault().Value;
                    if (dct == null) { }
                    _LinkedIds.Add(GetType(), value);
                }
            }
}
    }
}
