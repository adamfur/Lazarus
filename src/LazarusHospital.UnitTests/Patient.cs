using LazarusHospital.UnitTests.Conditions;
using LazarusHospital.UnitTests.Employee.Roles;
using LazarusHospital.UnitTests.Interfaces;

namespace LazarusHospital.UnitTests
{
    public class Patient : Resource, ICondition
    {
        public Condition Condition { get; private set; }

        public Patient(string name, Condition condition)
            : base(name)
        {
            Condition = condition;
        }

        public void Accept(IConditionVisistor visitor)
        {
            Condition.Accept(visitor);
        }
    }
}