using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzyNet.Functions;

namespace FuzzyNet.Fuzzification
{
    public class Parser
    {
        FuzzyInferenceSystem fis;

        public Parser(FuzzyInferenceSystem fis)
        {
            this.fis = fis;
        }

        public int ScanMatchingBrace(string expression, int startBraceIndex)
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

        private Condition GetConditionFromFis(Variable vari, string conditionName)
        {
            foreach(var v in fis.InputVariables[vari])
            {
                if (v.Name == conditionName)
                    return v;
            }
            throw new Exception("Condition " + conditionName + " not found in FIS");
        }

        public Node ParseInputSyntax(Node rootNode, string expression)
        {
            expression = expression.ToUpper();
            int firstSBrac = expression.IndexOf('(');
            int firstEBrac = ScanMatchingBrace(expression, firstSBrac);

            // base case, raw expression
            if (firstEBrac == -1 || firstSBrac == -1)
            {
                int isIndex = expression.IndexOf("IS");

                string left = expression.Substring(0, isIndex - 1);
                string right = expression.Substring(isIndex + 3);

                Variable inputVar = new Variable(left);
                // Condition cond = new Condition(right);

                Condition cond = GetConditionFromFis(inputVar, right);
   

                return new Clause(inputVar, cond);
            }

            string leftParse = expression.Substring(firstSBrac + 1, firstEBrac - 2);
            Node leftOperand = new Node();
            rootNode.LeftOperand = ParseInputSyntax(leftOperand, leftParse);

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
            rootNode.RightOperand = ParseInputSyntax(rightOperand, rightParse);

            return rootNode;

        }



        public Rule ParseLexicalStatement(string expression)
        {
            //IF blah THEN blah
            expression = expression.Substring(3);
            int indexOfThen = expression.IndexOf("THEN") + 4;
            string inputSynt = expression.Substring(0, indexOfThen).TrimEnd();

            Node inputNode = new Node();
            inputNode = ParseInputSyntax(inputNode, inputSynt);

            expression = expression.Substring(indexOfThen);


            // output
            int isIndex = expression.IndexOf("is");

            string left = expression.Substring(0, isIndex - 1);
            string right = expression.Substring(isIndex + 3);

            Variable outputVar = new Variable(left);

            Condition cond = GetConditionFromFis(outputVar, right);


            Rule r = new Rule();
            r.InputClause = inputNode;
            r.OutputClause = new Clause(outputVar, cond);

            return r;
        }
    }
}
