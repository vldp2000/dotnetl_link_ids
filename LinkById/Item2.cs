using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkById
{
    public class Item2: ALinkedById
    {
        public Item2(Dictionary<int, int> ids) : base(ids) { }
        public Item2(int id) : base(id) { }


    }
}
