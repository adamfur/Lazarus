using LazarusHospital.UnitTests.Employee.Roles;
using LazarusHospital.UnitTests.Interfaces;

namespace LazarusHospital.UnitTests.Conditions
{
    public abstract class Condition : ICondition
    {
        public abstract bool CanBeTreatedBy(IConditionVisistor visitor);
    }
}