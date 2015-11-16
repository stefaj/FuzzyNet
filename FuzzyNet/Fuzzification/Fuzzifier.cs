using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Fuzzification
{
    public class Fuzzifier
    {

        public Fuzzifier()
        {
        }

        public FuzzyVariables Fuzzify(FuzzyInputValues values, IEnumerable<Rule> rules)
        {            
            FuzzyNet.Accumulation.Maximum max = new Accumulation.Maximum();

            // i hope this stores unique output variable names

            FuzzyVariables outputMemberships = new FuzzyVariables();

            foreach(var rule in rules)
            {
                foreach (var k in values.Keys)
               {
                   rule.SetValue(k, values[k]);
                   k.Value = values[k];
                   
               }

               if (!outputMemberships.ContainsKey(rule.OutputClause.Variable))
               {
                   outputMemberships[rule.OutputClause.Variable] = new FuzzyVariableOutputs();
               }

               var condition = rule.OutputClause.Condition;
               float degree = rule.EvaluateDegree();

               outputMemberships[rule.OutputClause.Variable].Add(new ConditionDegree(condition,degree));
                
            }

            return outputMemberships;
        }


    }
}
