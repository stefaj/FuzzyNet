using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Membership
{
    public class Gaussian : IMembership
    {
        float sig, c;

        public Gaussian(float sig, float c)
        {
            this.sig = sig;
            this.c = c;
        }

        public float MembershipDegree(float x)
        {
            return (float)Math.Exp((-(x - c) * (x - c)) / (2 * sig * sig));
        }
    }
}
