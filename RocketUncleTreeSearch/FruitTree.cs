using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketUncleTreeSearch
{
    public class FruitTree : Branch
    {
        public int CountFruit<TFruit>() where TFruit : IFruit
        {
            return CountFruit<TFruit>(this.ChildBranches);
        }

        public int CountFruit<TFruit>(IEnumerable<Branch> branches) where TFruit : IFruit
        {
            var result =
                branches
                .Flatten(m => m.ChildBranches)
                .Where(i => i.Fruits != null)
                .SelectMany(i => i.Fruits)
                .Where(i => i is TFruit)
                .Count();

            return result;
        }

        public Tuple<Branch, int> GetBranchWithMostFruits()
        {
            return this.ChildBranches.Select(branch =>
            {
                if (branch.ChildBranches == null)
                    return new Tuple<Branch, int>(branch, branch.Fruits.Count());
                else
                {
                    var count =
                    branch.ChildBranches
                    .Flatten(m => m.ChildBranches)
                    .Where(i => i.Fruits != null)
                    .SelectMany(i => i.Fruits)
                    .Count();

                    return new Tuple<Branch, int>(branch, count);
                }
            })
            .OrderByDescending(i => i.Item2)
            .First();
        }

        public IFruit GetLeftMostFruit()
        {
            return PostOrderTraverse(this).Where(i => i.Fruits != null).Where(i => i.Fruits.Any()).SelectMany(i => i.Fruits).FirstOrDefault();
        }

        private IEnumerable<Branch> PostOrderTraverse(Branch branch)
        {
            if (branch.ChildBranches != null) 
            { 
                foreach (var b in branch.ChildBranches)
                {
                    foreach (var n in PostOrderTraverse(b))
                    {
                        yield return n;
                    }
                }
            }

            yield return branch;
        }
    }
}
