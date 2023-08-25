using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkById
{
    public class Item2 : ALinkedById, ISubstitute
    {
        public Item2(int id, string code)
        {
            Id = id;
            Code = code;
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public override int PropertyToBeLinked { get => Id; }

    }
}
