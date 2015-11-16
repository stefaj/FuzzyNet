using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Membership
{
    public class Trapeziodal : IMembership
    {
        float a, b, c, d;

        public Trapeziodal(float a, float b, float c, float d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public float MembershipDegree(float x)
        {
            if (x < a)
                return 0;
            else if (x < b)
            {
                return (x - a) / (b - a);
            }
            else if (x <= c)
                return 1;
            else if (x <= d)
            {
                return (d - x) / (d - c);
            }
            else
                return 0;
        }


        public float Center
        {
            get { return (d - a) / 2; }
        }

        public float Area
        {
            get { return 1.0f / 2.0f * ((c - b) + (d - a)) * 1; }
        }
    }
}
