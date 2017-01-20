using LazarusHospital.UnitTests.Employee.Roles;
using LazarusHospital.UnitTests.Interfaces;
using LazarusHospital.UnitTests.TreatmentRooms.Machines;

namespace LazarusHospital.UnitTests.Conditions
{
    public class Flu : Condition
    {
        public override bool Accept(IConditionVisistor visitor)
        {
            return visitor.Visit(this);
        }
    }
}