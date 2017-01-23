using LazarusHospital.Conditions;
using LazarusHospital.Interfaces;

namespace LazarusHospital
{
    public class Patient : Resource, ICondition
    {
        private Condition Condition { get; set; }

        public Patient(string name, Condition condition)
            : base(name)
        {
            Condition = condition;
        }

        public bool CanBeTreatedBy(IConditionVisistor visitor)
        {
            return Condition.CanBeTreatedBy(visitor);
        }

        public override string ToString()
        {
            return $"{Name} ({Condition})";
        }
    }
}
