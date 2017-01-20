using LazarusHospital.UnitTests.Interfaces;
using LazarusHospital.UnitTests.TreatmentRooms.Machines;

namespace LazarusHospital.UnitTests.TreatmentRooms
{
    public class TreatmentRoom : Resource, ICanTreat, IConditionVisistor
    {
        private TreatmentMachine TreatmentMachine { get; set; }

        public TreatmentRoom(string name, TreatmentMachine treatmentMachine)
            : base(name)
        {
            TreatmentMachine = treatmentMachine;
        }

        public bool CanTreat(Patient patient)
        {
            return TreatmentMachine.CanTreat(patient);
        }
    }
}