using LazarusHospital.UnitTests.Conditions;

namespace LazarusHospital.UnitTests
{
    public class Patient : Resource
    {
        public Condition Condition { get; private set; }

        public Patient(string name, Condition condition)
            : base(name)
        {
            
        }
    }
}