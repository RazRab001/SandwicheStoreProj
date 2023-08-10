using SandwicheStoreProj.SandwicheStoreProj;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwicheStoreProj
{
    public class FirstKitchenApp : KitchenApp
    {
        public SaveCatalog<Bread> breads = new SaveCatalog<Bread>("breads_catalog.xml");
        public SaveCatalog<Ingridient> ingridients = new SaveCatalog<Ingridient>("ingridients_catalog.xml");
        public SaveCatalog<Sandvich> sandviches = new SaveCatalog<Sandvich>("sandvich_catalog.xml");
        //public List<Sandvich> sandviches = new List<Sandvich>();
        Ingridient ingridient;
        Bread bread;

        public void addBread(Bread bread)
        {
            breads.AddItem(bread);
            Debug.WriteLine(bread.Name);
        }

        public void addBreadToSandvich(string bread)
        {
            this.bread = Bread.Create(this, bread);
        }

        public void addIngridient(Ingridient ingridient)
        {
            ingridients.AddItem(ingridient);
        }

        public void addIngridientToSandvich(string ingridient)
        {
            if(bread != null)
            {
                foreach(Ingridient i in ingridients.GetCatalog())
                {
                    if(i.Name == ingridient)
                    {
                        if(this.ingridient != null)
                        {
                            Ingridient added = this.ingridient;
                            this.ingridient = new Ingridient(added, ingridient);
                            Debug.WriteLine($"{this.ingridient.Name} added to sandvich");
                        }
                        else
                        {
                            this.ingridient = new Ingridient(bread, ingridient);
                            Debug.WriteLine($"{this.ingridient.Name} added to sandvich");
                        }
                    }
                }
            }
        }

        public void createNewSandvich(string name)
        {
            if(ingridient != null)
            {
                foreach (Sandvich sandvich in sandviches.GetCatalog())
                {
                    if (sandvich.Name == name) { return; }
                }
                sandviches.AddItem(new Sandvich(name, ingridient));
            }
            else
            {
                Debug.WriteLine("Ingridient is empty");
            }
        }

        public List<Bread> getBreads() => breads.GetCatalog();

        public List<Ingridient> getIngridients() => ingridients.GetCatalog();
    }
}
