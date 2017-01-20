using LazarusHospital.UnitTests.Conditions;

namespace LazarusHospital.UnitTests.Interfaces
{
    public interface IConditionVisistor
    {
        bool Visit(Flu condition);
        bool Visit(Cancer condition);
    }
}