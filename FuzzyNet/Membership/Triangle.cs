using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Membership
{
    public class Triangle : IMembership
    {
        float a, b, c;

        public Triangle(float a, float b, float c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public float MembershipDegree(float x)
        {
            if (x < a)
                return 0;
            else if (x <= b)
            {
                return (x - a) / (b - a);
            }
            else if (x <= c)
            {
                return (c - x) / (c - b);
            }
            else
                return 0;
        }
    }
}
