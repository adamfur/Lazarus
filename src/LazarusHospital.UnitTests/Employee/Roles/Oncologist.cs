namespace LazarusHospital.UnitTests.Employee.Roles
{
    public class Oncologist : Role
    {
        public override bool CanTreat(Patient patient)
        {
            return patient.Condition.Visit(this);
        }        
    }
}