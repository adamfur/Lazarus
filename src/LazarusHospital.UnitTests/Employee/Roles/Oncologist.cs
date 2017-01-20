using LazarusHospital.UnitTests.Conditions;

namespace LazarusHospital.UnitTests.Employee.Roles
{
    public class Oncologist : Role
    {
        public override bool CanTreat(Patient patient)
        {
            //return patient.Condition.Visit(this);
            return true;
        }

        public override void Visit(Flu condition)
        {
        }

        public override void Visit(Cancer condition)
        {
        }
    }
}