using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzyNet.Functions;

namespace FuzzyNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //IF ((temperature is hot) OR (temperature is too-hot)) AND (target is warm) THEN command is cool

            //((temperature is hot) OR (temperature is too-hot)) AND (target is warm)
            Node rootNode = new Node();


            var a = ParseTree(rootNode, "((temperature is hot) OR (temperature is too-hot)) AND (target is warm)");

            Console.WriteLine(a.ToString());

            Console.ReadLine();
        }
    }
}
