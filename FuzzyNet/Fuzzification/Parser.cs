using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzyNet.Functions;

namespace FuzzyNet.Fuzzification
{
    public static class Parser
    {
        public static int ScanMatchingBrace(string expression, int startBraceIndex)
        {
            int braceCount = 1;

            startBraceIndex++;

            try
            {
                while (braceCount > 0)
                {
                    int c = expression[startBraceIndex];
                    if (c == '(')
                        braceCount++;
                    if (c == ')')
                        braceCount--;

                    startBraceIndex++;
                }
            }
            catch
            {
                return -1;
            }

            return startBraceIndex;

        }

        public static Node ParseTree(Node rootNode, string expression)
        {
            int firstSBrac = expression.IndexOf('(');
            int firstEBrac = ScanMatchingBrace(expression, firstSBrac);

            // base case, raw expression
            if (firstEBrac == -1 || firstSBrac == -1)
            {
                int isIndex = expression.IndexOf("is");

                string left = expression.Substring(0, isIndex - 1);
                string right = expression.Substring(isIndex + 3);

                return new Clause("is", left, right);

            }

            string leftParse = expression.Substring(firstSBrac + 1, firstEBrac - 2);
            Node leftOperand = new Node();
            rootNode.LeftOperand = ParseTree(leftOperand, leftParse);

            expression = expression.Substring(firstEBrac).TrimStart();
            string function = expression.Substring(0, expression.IndexOf(' '));
            IFunction func = null;
            switch (function.ToLower().Trim())
            {
                case "and":
                    func = new AndFunction();
                    break;
                case "or":
                    func = new OrFunction();
                    break;
                default:
                    break;
            }
            rootNode.Function = func;
            expression = expression.Substring(expression.IndexOf(' ') + 1);


            int lastSBrac = expression.IndexOf('(');
            int lastEBrac = ScanMatchingBrace(expression, firstSBrac);

            string rightParse = expression.Substring(lastSBrac + 1, lastEBrac - 2);
            Node rightOperand = new Node();
            rootNode.RightOperand = ParseTree(rightOperand, rightParse);



            return rootNode;

        }
    }
}
