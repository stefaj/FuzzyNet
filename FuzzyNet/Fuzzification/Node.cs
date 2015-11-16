using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet
{
    public class Node
    {

        public Node()
        {

        }

        public Node(IFunction function, Node left, Node right)
        {
            this.Function = function;
            this.LeftOperand = left;
            this.RightOperand = right;
        }

        public virtual IFunction Function { get; set; }

        public virtual Node LeftOperand { get; set; }

        public virtual Node RightOperand { get; set; }

        public override string ToString()
        {
            if (LeftOperand == null || RightOperand == null)
                return Function.ToString();

            return string.Format("({0} {1} {2})", LeftOperand.ToString(), Function.ToString(), RightOperand.ToString());
        }

        public virtual float Evaluate()
        {
            return Function.Evaluate(this.LeftOperand.Evaluate(), this.RightOperand.Evaluate());
        }
    }
}
