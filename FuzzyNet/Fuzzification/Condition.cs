using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Fuzzification
{
    public class Condition
    {
        public string Name { get; set; }

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

        public static explicit operator Condition(string s)
        {
            return new Condition() { Name = s };
        }

        public static implicit operator Condition(string s)
        {
            return new Condition() { Name = s };
        }
    }
}
