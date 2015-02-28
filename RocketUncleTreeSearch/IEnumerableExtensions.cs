using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketUncleTreeSearch
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> e, Func<T, IEnumerable<T>> f)
        {
            return e.Concat(e.SelectMany(c =>
            {
                var childrens = f(c);

                return childrens == null ? Enumerable.Empty<T>() : childrens.Flatten(f);
            }));
        }
    }
}
