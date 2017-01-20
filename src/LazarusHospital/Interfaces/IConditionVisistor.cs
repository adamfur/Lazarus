using LazarusHospital.UnitTests.Conditions;

namespace LazarusHospital.UnitTests.Interfaces
{
    public interface IConditionVisistor
    {
        bool CanTreatCondition(Flu condition);
        bool CanTreatCondition(Cancer condition);
    }
}