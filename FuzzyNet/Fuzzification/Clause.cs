using FuzzyNet.Fuzzification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet
{
    public class Clause : Node
    {

        float value;

        Condition condition;
        Variable variable;

        public Variable Variable { get
            {
                return variable;
            }
        }

        public Condition Condition
        {
            get
            {
                return condition;
            }
        }

        public Clause(Variable variable, Condition condition)
        {
            this.Function = null;
            this.condition = condition;
            this.variable = variable;
        }

        public void SetValue(float val)
        {
            this.value = val;
        }

        public float GetValue()
        {
            return this.value;
        }

        public override float Evaluate()
        {
            return condition.Membership.MembershipDegree(this.value);
        }

        public override string ToString()
        {
            return string.Format("({0} IS {1})",Variable.ToString(), condition.ToString());
        }
    }
}
