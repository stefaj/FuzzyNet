using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Fuzzification
{
    public class FuzzyVariables : Dictionary<Variable, FuzzyVariableOutputs>
    {

    }

    public class ConditionDegree : Tuple<Condition, float>
    {
        public ConditionDegree(Condition d, float degree) : base(d, degree)
        {
        
        }
    }

    public class FuzzyVariableOutputs : List<ConditionDegree>
    {

    }

    public class FuzzyInputValues : Dictionary<Variable, float>
    { 
    }
    

    public class FuzzyConditions : Dictionary<Variable, List<Condition>>
    {

    }

}
