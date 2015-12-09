using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Membership
{
    /// <summary>
    /// 1 when (x-a) == 0 otherwise 0
    /// </summary>
    public class Singleton : IMembership
    {
        float unitPos;

        public Singleton(float unitPos)
        {
            this.unitPos = unitPos;
        }

        public float MembershipDegree(float x)
        {
            if (x - unitPos == 0)
                return 1;
            else
                return 0;
        }

        public float Center
        {
            get { return unitPos; }
        }

        public float Area
        {
            get 
            {
                return 1; 
            }
        }
    }
}
