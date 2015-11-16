using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Membership
{
    public interface IMembership
    {
        /// <summary>
        /// Returns the degree of which a variable corresponds to a membership given by this membership function
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        float MembershipDegree(float pos);

        float Center { get; }

        float Area { get; }
    }
}
