using LazarusHospital.UnitTests.Conditions;

namespace LazarusHospital.UnitTests.Employee.Roles
{
    public class GeneralPractitioner : Role
    {
        public override bool Visit(Flu condition)
        {
            return true;
        }

        public override bool Visit(Cancer condition)
        {
            return false;
        }
    }
}