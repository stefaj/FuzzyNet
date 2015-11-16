using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Fuzzification
{
    public class Rule
    {

        Dictionary<Variable, Clause> inputVariables;

        public Rule()
        {
            inputVariables = new Dictionary<Variable, Clause>();
        }

        // List<Clause> InputVariables { get; private set; }
        public Node InputClause { get; set; }

        public Clause OutputClause { get; set; }

        public void BuildInputVariables()
        {
            AddInputVariableFromNode(InputClause);
        }


        private void AddInputVariableFromNode(Node node)
        {
            if (node.LeftOperand as Clause != null)
            {
                var c = (node.LeftOperand as Clause);
                inputVariables[c.Variable] = c;
            }
            else if (node.RightOperand as Clause != null)
            {
                var c = (node.RightOperand as Clause);
                inputVariables[c.Variable] = c;
            }
            else
            {
                AddInputVariableFromNode(node.LeftOperand);
                AddInputVariableFromNode(node.RightOperand);
            }
        }

        public void SetValue(Variable var, float value)
        {
            inputVariables[var].SetValue(value);
        }

        public float EvaluateDegree()
        {
            return InputClause.Evaluate();
        }

        public override string ToString()
        {
            return string.Format("IF {0} THEN {1}", InputClause.ToString(), OutputClause.ToString());
        }

    }
}
