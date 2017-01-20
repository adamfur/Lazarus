using LazarusHospital.Conditions;

namespace LazarusHospital.Interfaces
{
    public interface IConditionVisistor
    {
        bool CanTreatCondition(Flu condition);
        bool CanTreatCondition(Cancer condition);
    }
}