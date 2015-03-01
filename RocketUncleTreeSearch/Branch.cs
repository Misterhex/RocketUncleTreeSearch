using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketUncleTreeSearch
{
    public class Branch
    {
        public IEnumerable<IFruit> Fruits { get; set; }

        public IEnumerable<Branch> ChildBranches { get; set; }
    }
}
