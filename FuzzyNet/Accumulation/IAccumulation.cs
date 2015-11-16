using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzyNet.Fuzzification;

namespace FuzzyNet.Accumulation
{
    interface IAccumulation
    {
        public float Accumulate(Rule rule1, Rule rule2);
    }
}
