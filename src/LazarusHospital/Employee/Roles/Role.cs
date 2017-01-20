using LazarusHospital.Conditions;
using LazarusHospital.Interfaces;

namespace LazarusHospital.Employee.Roles
{
    public abstract class Role : IConditionVisistor
    {
        public abstract bool CanTreatCondition(Flu condition);
        public abstract bool CanTreatCondition(Cancer condition);
    }
}