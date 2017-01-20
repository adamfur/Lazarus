using LazarusHospital.Conditions;
using LazarusHospital.Interfaces;

namespace LazarusHospital.TreatmentRooms.Machines
{
    public abstract class TreatmentMachine : Resource, IConditionVisistor
    {
        protected TreatmentMachine(string name)
            : base(name)
        {
        }

        public abstract bool CanTreatCondition(Cancer condition);
        public abstract bool CanTreatCondition(Flu condition);
    }
}