using LazarusHospital.UnitTests.Interfaces;

namespace LazarusHospital.UnitTests.TreatmentRooms.Machines
{
    public abstract class TreatmentMachine : Resource, ICanTreat
    {
        protected TreatmentMachine(string name)
            : base(name)
        {
        }

        public abstract bool CanTreat(Patient patient);
    }
}