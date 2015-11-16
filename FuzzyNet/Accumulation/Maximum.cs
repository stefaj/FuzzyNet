using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Accumulation
{
    public class Maximum : IAccumulation
    {

        public float Accumulate(Node exp1, Node exp2)
        {
            return Math.Max(exp1.Evaluate(), exp2.Evaluate());
        }

        public float Accumulate(params Node[] nodes)
        {
            float max = 0;

            max = Math.Max(nodes[0].Evaluate(), nodes[1].Evaluate());
            for (int i = 1; i < nodes.Length; i++ )
            {
                max = Math.Max(max, nodes[i].Evaluate());
            }
            return max;
        }

    }
}
