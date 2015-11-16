using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Fuzzification
{
    public class Fuzzifier
    {

        public OutputVariable[] Fuzzify(params Rule[] rules)
        {
            
            FuzzyNet.Accumulation.Maximum max = new Accumulation.Maximum();

            // i hope this stores unique output variable names
            HashSet<OutputVariable> outputSet = new HashSet<OutputVariable>();

            foreach(var rule in rules)
            {
                float mem = rule.InputRootNode.Evaluate();
                rule.OutputVariable.Degree = mem;

                if (outputSet.Contains(rule.OutputVariable))
                {
                    foreach (OutputVariable v in outputSet)
                    {
                        if (v.Equals(rule.OutputVariable))
                        {
                            if (v.Degree > rule.OutputVariable.Degree)
                            {
                                outputSet.Remove(v);
                                outputSet.Add(rule.OutputVariable);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    outputSet.Add(rule.OutputVariable);
                }
            }

            return outputSet.ToArray();`
        }
    }
}
