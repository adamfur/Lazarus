using LazarusHospital.UnitTests.Conditions;
using LazarusHospital.UnitTests.Interfaces;

namespace LazarusHospital.UnitTests.TreatmentRooms.Machines
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