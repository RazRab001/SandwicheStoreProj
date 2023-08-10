using SandwicheStoreProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwicheStoreProj
{
    public class SortByName : IComparer<Ingridients>
    {
        public int Compare(Ingridients x, Ingridients y)
        {
            return string.Compare(x.Name, y.Name);
        }
    }
}
