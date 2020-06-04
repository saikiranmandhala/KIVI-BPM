using System.Collections.Generic;

namespace KIVI.BPM.RulesEngine
{
    public class BrokenRule
    {
        public string Name { get; set; }
        public string ErrorMessage { get; set; }
    }

    public abstract class Rule
    {
        //public abstract BrokenRule Validate(object value, Context context);
        public abstract BrokenRule Validate();


    }

    public class RuleEngine
    {
        public RuleEngine()
        {
            this.Rules = new List<Rule>();
        }

        public List<Rule> Rules;
        List<BrokenRule> BrokenRules { get; set; }


        public void AddRule(Rule rule)
        {
            this.Rules.Add(rule);
        }

        public void ExecuteRules()
        {
            Rules.ForEach(rule =>
            {
                BrokenRules.Add(
                    rule.Validate()
                    );
            });
        }
    }

    public class IntakeMethodRule : Rule
    {
        private object value;
        IntakeMethodRule(object value)
        {
            this.value = value;
        }

        public override BrokenRule Validate() //object value, Context context
        {
            throw new System.NotImplementedException();
        }
    }


    public class RelatedPartyRule : Rule
    {
        private object value;
        RelatedPartyRule(object value)
        {
            this.value = value;
        }

        public override BrokenRule Validate() //object value, Context context
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IAllegation
    {
        //List<BrokenRule> BrokenRules { get; set; }

        //List<BrokenRule> ExecuteRules();


    }

    public class AllegationStartResult
    {
        public bool success { get { return brokenRules.Count <= 0; } }
        public List<BrokenRule> brokenRules { get; set; }

        AllegationStartResult()
        {
            brokenRules = new List<BrokenRule>();
        }
    }

    public class Allegation : IAllegation
    {
        RuleEngine ruleEngine = new RuleEngine();
        protected AllegationStartResult allegationStartResult;

        public AllegationStartResult Start()
        {

            // broken rules in the base

            this.allegationStartResult.brokenRules.Add(new BrokenRule());

            return allegationStartResult;
        }

    }

    public class EIAllegation : Allegation
    {

        public List<Rule> Rules;

        public new AllegationStartResult Start()
        {
            this.Start();
            return allegationStartResult;
        }
    }
}

