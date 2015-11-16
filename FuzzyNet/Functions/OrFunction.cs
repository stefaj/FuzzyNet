using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Functions
{
    public class OrFunction : IFunction
    {
        public float Evaluate(float v1, float v2)
        {
            return Math.Max(v1, v2);
        }

        public override string ToString()
        {
            return "Or";
        }
    }
}
