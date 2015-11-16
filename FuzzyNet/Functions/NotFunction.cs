using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Functions
{
    public class NotFunction : IFunction
    {
        public float Evaluate(float v1, float v2)
        {
            return 1 - v1;
        }


        public override string ToString()
        {
            return "Not";
        }
    }
}
