using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Defuzzification
{
    public class WeightedAverage : IDefuzzifier
    {

        public float Defuzzify(Fuzzification.FuzzyVariableOutputs values)
        {
            float num = 0;
            float denum = 0;

            foreach(var k in values)
            {
                num += (k.Item2 * k.Item1.Membership.Center);
                denum += k.Item2;
            }

            return num / denum;
        }
    }
}
