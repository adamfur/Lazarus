using LazarusHospital.UnitTests.Conditions;
using LazarusHospital.UnitTests.Interfaces;

namespace LazarusHospital.UnitTests.Employee.Roles
{
    public abstract class Role : ICanTreat, IConditionVisistor
    {
        public abstract bool CanTreat(Patient patient);
        public abstract void Visit(Flu condition);
        public abstract void Visit(Cancer condition);
    }
}