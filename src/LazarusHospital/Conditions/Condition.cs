using LazarusHospital.Interfaces;

namespace LazarusHospital.Conditions
{
    public abstract class Condition : ICondition
    {
        public abstract bool CanBeTreatedBy(IConditionVisistor visitor);
    }
}