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

        public abstract bool Visit(Cancer condition);
        public abstract bool Visit(Flu condition);
    }
}