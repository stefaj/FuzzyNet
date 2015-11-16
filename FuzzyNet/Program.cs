using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzyNet.Functions;
using FuzzyNet.Fuzzification;
using FuzzyNet.Membership;

namespace FuzzyNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //IF ((temperature is hot) OR (temperature is too-hot)) AND (target is warm) THEN command is cool

            //((temperature is hot) OR (temperature is too-hot)) AND (target is warm)
            Node rootNode = new Node();


            FuzzyInferenceSystem fis = new FuzzyInferenceSystem();



            //input conditions
            Condition cold = new Condition("cold", new Triangle(-0.4f,0.0f,0.4f));
            Condition medium = new Condition("medium", new Triangle(0.1f,0.5f,0.9f));
            Condition warm = new Condition("hot", new Triangle(0.6f,1.0f,1.4f));
            Variable inputHeat = new Variable("heat");
            fis.AddInputVariableMembership(inputHeat, new Condition[]{cold,medium,warm});

            Condition down = new Condition("down", new Triangle(-0.4f,0.0f,0.4f));
            Condition up = new Condition("up", new Triangle(0.6f,1.0f,1.4f));
            Variable outputMotion = new Variable("motion");
            fis.AddOutputVariableMembership(outputMotion, new Condition[]{down,up});

            fis.AddRule("IF heat is medium then motion is down");
            fis.AddRule("IF heat is cold then motion is up");

            
            //Test
            fis.SetInputVariable(inputHeat, 0.2f);
            fis.Run();
            float val = fis.GetOutputVariableValue("motion");


            Console.WriteLine("Input {0} -> Output {1}", inputHeat.Value, val);

            
            Console.ReadLine();
        }
    }
}
