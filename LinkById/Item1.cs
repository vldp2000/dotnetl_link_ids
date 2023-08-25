using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkById
{
    public class Item1: ALinkedById , ISubstitute
    {
        public int RefJob { get; set; }
        public Item1(int refJob) => RefJob = refJob;

        public override int PropertyToBeLinked { get => RefJob; }


    }
}
