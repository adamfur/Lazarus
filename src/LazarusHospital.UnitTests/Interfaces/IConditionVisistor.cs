using LazarusHospital.UnitTests.Conditions;

namespace LazarusHospital.UnitTests.Interfaces
{
    public interface IConditionVisistor
    {
        void Visit(Flu condition);
        void Visit(Cancer condition);
    }
}