using LazarusHospital.Conditions;

namespace LazarusHospital.Employee.Roles
{
    public class GeneralPractitioner : Role
    {
        public override bool CanTreatCondition(Flu condition)
        {
            return true;
        }

        public override bool CanTreatCondition(Cancer condition)
        {
            return false;
        }
    }
}