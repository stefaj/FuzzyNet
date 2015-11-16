using FuzzyNet.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Fuzzification
{
    public class Condition
    {

        public Condition(string name, IMembership membership)
        {
            this.Name = name.ToUpper();
            this.Membership = membership;
        }

        public string Name { get; set; }

        public IMembership Membership {get; set;}

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Name.Equals(obj);
        }

    }
}
