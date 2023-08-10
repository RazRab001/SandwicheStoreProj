using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SandwicheStoreProj
{
    [KnownType(typeof(Bread))]
    [KnownType(typeof(Ingridient))]
    [DataContract]
    public class Sandvich
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        Ingridient Ingridient { get; set; }
        public Sandvich(string name, Ingridient ingridient)
        {
            
                Name = name;
                Ingridient = ingridient;
        }
        public override string ToString()
        {
            return $"{Name}:\n{Ingridient.getName()}";
        }
    }
}
