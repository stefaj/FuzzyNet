using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet.Fuzzification
{
    public class Variable : Node
    {
        public string Name { get; set; }


        /// <summary>
        /// For temporary computations
        /// </summary>
        public float Value { get; set; }
        
        public Variable(string name)
        {
            this.Name = name.ToUpper();
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Name == obj.ToString();
        }


     /*   public static explicit operator Variable(string s)
        {
            return new Variable(s);
        }
        */
        public static implicit operator Variable(string s)
        {
            return new Variable(s);
        }

    }
}
