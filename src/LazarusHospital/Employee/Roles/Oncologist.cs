using LazarusHospital.UnitTests.Conditions;

namespace LazarusHospital.UnitTests.Employee.Roles
{
    public class Oncologist : Role
    {
        public override bool CanTreatCondition(Flu condition)
        {
            return false;
        }

        public override bool CanTreatCondition(Cancer condition)
        {
            return true;
        }
    }
}