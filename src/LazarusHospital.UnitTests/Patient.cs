using LazarusHospital.UnitTests.Conditions;

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

        public bool Accept(IPatientVisitor visitor)
        {
            return Condition.Accept(visitor);
        }
    }

    public interface IPatientVisitor
    {
        bool Visit(Flu flu);
        bool Visit(Cancer flu);
    }
}