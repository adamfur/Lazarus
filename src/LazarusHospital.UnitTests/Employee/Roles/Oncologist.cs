using LazarusHospital.UnitTests.Conditions;

namespace LazarusHospital.UnitTests.Employee.Roles
{
    public class Oncologist : Role
    {
        public override bool Visit(Flu condition)
        {
            return false;
        }

        public override bool Visit(Cancer condition)
        {
            return true;
        }
    }
}