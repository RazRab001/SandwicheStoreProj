using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwicheStoreProj
{
    public interface KitchenApp
    {
        List<Bread> getBreads();
        List<Ingridient> getIngridients();
        void addBread(Bread bread);
        void addIngridient(Ingridient ingridient);
        void addBreadToSandvich(string bread);
        void addIngridientToSandvich(string ingridient);
        void createNewSandvich(string name);
    }
}
