using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkById
{
    internal interface ILinkedById
    {
        int Id { get; }

        int? LinkedId { get; }

        bool LinkedFlag { get; }
        Dictionary<int, int>? LinkedIds { get; set; }        

    }
}
