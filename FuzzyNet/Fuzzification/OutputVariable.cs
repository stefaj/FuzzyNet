using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Fuzzification
{
    public class OutputVariable
    {
        public string Name { get; set; }
        public Condition Condition { get; set; }
        public float Degree { get; set; }

        public override int GetHashCode()
        {
            return (Name + Condition.Name).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj.ToString() == (Name + Condition.Name);
        }
    }
}
