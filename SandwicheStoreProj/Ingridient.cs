using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SandwicheStoreProj
{

    [KnownType(typeof(Bread))]
    [DataContract]
    public class Ingridient : Ingridients
    {
        [DataMember]
        Ingridients ing;

        [DataMember]
        public string Name { get; set; }
        private Ingridient(string name)
        {
            Name = name;
        }
        public static Ingridient Create(KitchenApp app, string name)
        {
            foreach (Ingridient ingridient in app.getIngridients())
            {
                if (ingridient.Name == name)
                {
                    return ingridient;
                }
            }
            Ingridient i = new Ingridient(name);
            app.addIngridient(i);
            Debug.WriteLine($"Ingridient {name} created");
            return i;
        }
        
        public Ingridient(Ingridients ingridients, string name)
        {
            Name = name;
            ing = ingridients;
            Debug.WriteLine(ing.Name);
        }
        public string getName() => ing.getName() + ", " + this.Name;
        public override string ToString() => Name;
    }
}
