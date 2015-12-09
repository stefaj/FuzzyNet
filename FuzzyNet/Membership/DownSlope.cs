using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Membership
{

    //
    //          \         
    //           \                 
    //            a------b
    //                    \        
    //                     \

    public class DownSlope : IMembership
    {
        float a, b;

        public DownSlope(float a, float b, float c)
        {
            this.a = a;
            this.b = b;
        }

        public float MembershipDegree(float x)
        {
            if (x < a)
                return 0;
            if (x > b)
                return 1;
            else
                return (x - a) / (a - b);
        }


        public float Center
        {
            get { return (a-b)/2; }
        }

        public float Area
        {
            get 
            {
                return 1.0f / 2.0f * (a - b);
            }
        }
    }
}
