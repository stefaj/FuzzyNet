using FuzzyNet.Fuzzification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Defuzzification
{
    interface IDefuzzifier
    {
        float Defuzzify(FuzzyVariableOutputs values);

    }
}
