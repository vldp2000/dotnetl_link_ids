using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkById
{
    internal interface ILinkedById
    {
        int OriginalValue { get; }

        int? LinkedValue { get; }

        bool LinkedFlag { get; }

    }
}
