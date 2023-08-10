using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SandwicheStoreProj
{
    [DataContract]
    public class Bread : Ingridients
    {
        [DataMember]
        public string Name { get; set; }
        private Bread(string name) 
        { 
            Name = name;
        }
        public static Bread Create(KitchenApp app, string name)
        {
            foreach (Bread bread in app.getBreads())
            {
                if (bread.Name == name)
                {
                    return bread;
                }
            }
            Bread b = new Bread(name);
            app.addBread(b);
            Debug.WriteLine($"Bread {name} created");
            return b;
        }
        public string getName() => Name;
        public override string ToString() => Name;
    }
}
