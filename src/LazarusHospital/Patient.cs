using LazarusHospital.Conditions;
using LazarusHospital.Interfaces;

namespace LazarusHospital
{
    public class Patient : Resource, ICondition
    {
        public Condition Condition { get; private set; }

        public Patient(string name, Condition condition)
            : base(name)
        {
            Condition = condition;
        }

        public bool CanBeTreatedBy(IConditionVisistor visitor)
        {
            return Condition.CanBeTreatedBy(visitor);
        }
    }
}