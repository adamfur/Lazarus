using LazarusHospital.Interfaces;

namespace LazarusHospital.Conditions
{
    public class Flu : Condition
    {
        public override bool CanBeTreatedBy(IConditionVisistor visitor)
        {
            return visitor.CanTreatCondition(this);
        }
    }
}