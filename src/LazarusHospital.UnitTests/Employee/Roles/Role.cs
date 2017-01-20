using LazarusHospital.UnitTests.Conditions;
using LazarusHospital.UnitTests.Interfaces;

namespace LazarusHospital.UnitTests.Employee.Roles
{
    public abstract class Role : IConditionVisistor
    {
        public abstract bool Visit(Flu condition);
        public abstract bool Visit(Cancer condition);
    }
}