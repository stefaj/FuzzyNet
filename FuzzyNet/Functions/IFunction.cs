using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet
{
    public interface IFunction
    {
        public float Evaluate(float v1, float v2);
    }
}
