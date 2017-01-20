using LazarusHospital.UnitTests.Conditions;
using LazarusHospital.UnitTests.Interfaces;

namespace LazarusHospital.UnitTests.TreatmentRooms.Machines
{
    public abstract class TreatmentMachine : Resource, ICanTreat, IConditionVisistor
    {
        protected TreatmentMachine(string name)
            : base(name)
        {
        }

        public abstract bool CanTreat(Patient patient);

        public void Visit(Flu condition)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(Cancer condition)
        {
            throw new System.NotImplementedException();
        }
    }
}