using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet
{
    public class Clause : Node
    {


        public Clause(string func, string var, string cond)
        {
            this.Function = func;
            this.LeftOperand = new Node(var, null, null);
            this.RightOperand = new Node(cond, null, null);
        }
    }
}
