using FuzzyNet.Defuzzification;
using FuzzyNet.Fuzzification;
using FuzzyNet.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNet
{
    public class FuzzyInferenceSystem
    {
        List<Rule> rules;

        public FuzzyConditions InputVariables{get; private set;}
        public FuzzyConditions OutputVariables{get; private set;}

        FuzzyInputValues inputValues;

        Fuzzifier fuzzy;

        IDefuzzifier defuzzy;

        public FuzzyInferenceSystem()
        {
            rules = new List<Rule>();
            InputVariables = new FuzzyConditions();
            OutputVariables = new FuzzyConditions();
            fuzzy = new Fuzzifier();

            inputValues = new FuzzyInputValues();

            // TODO
            defuzzy = new WeightedAverage();
        }


        public Variable GetOutputVariable(string name)
        {
            name = name.ToUpper();
            foreach(var v in OutputVariables.Keys)
            {
                if (v.Name == name)
                    return v;
            }
            throw new Exception("Not found output var " + name);
        }


        public float GetOutputVariableValue(string name)
        {
            return GetOutputVariable(name).Value;
        }


        public void AddRule(Rule r)
        {
            r.BuildInputVariables();
            this.rules.Add(r);
        }

        public void AddRule(string s)
        {
            Parser pars = new Parser(this);
            AddRule(pars.ParseLexicalStatement(s));
        }

        public void SetInputVariable(Variable v, float value)
        {
            inputValues[v] = value;
            v.Value = value;
        }

        public void AddInputVariableMembership(string variable, string conditionName, IMembership membership)
        {
            InputVariables[variable.ToUpper()].Add(new Condition(conditionName, membership));
        }

        public void AddInputVariableMembership(Variable v, IEnumerable<Condition> conditions)
        {
            InputVariables[v] = new List<Condition>();
            foreach (var c in conditions)
                InputVariables[v].Add(c);
        }

        public void AddOutputVariableMembership(Variable v, IEnumerable<Condition> conditions)
        {
            OutputVariables[v] = new List<Condition>();
            foreach (var c in conditions)
                OutputVariables[v].Add(c);
        }

        public void AddOutputVariableMembership(string variable, string conditionName, IMembership membership)
        {
            OutputVariables[variable.ToUpper()].Add(new Condition(conditionName, membership));
        }

        public void Run()
        {
            // fuzzify
            var fuzzyVars = fuzzy.Fuzzify(inputValues, rules);

            // defuzzy
            foreach(var outpuVar in fuzzyVars.Keys)
            {
                var fvo = fuzzyVars[outpuVar];
                var v = defuzzy.Defuzzify(fvo);
                this.GetOutputVariable(outpuVar.Name).Value = v;
            }
        }

    }
}
//    public class FuzzyVariables : Dictionary<Variable, FuzzyVariableOutputs>
//    public class FuzzyVariableOutputs : List<ConditionDegree>