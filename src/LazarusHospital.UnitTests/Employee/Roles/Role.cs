using LazarusHospital.UnitTests.Conditions;
using LazarusHospital.UnitTests.Interfaces;

namespace LazarusHospital.UnitTests.Employee.Roles
{
    public abstract class Role : IConditionVisistor
    {
        public abstract bool CanTreatCondition(Flu condition);
        public abstract bool CanTreatCondition(Cancer condition);
    }
}