using LazarusHospital.UnitTests.Conditions;

namespace LazarusHospital.UnitTests.Employee.Roles
{
    public class GeneralPractitioner : Role
    {
        public override bool CanTreat(Patient patient)
        {
            return true;
            //return patient.Accept(this);
        }

        public override void Visit(Flu condition)
        {
        }

        public override void Visit(Cancer condition)
        {
        }
    }
}