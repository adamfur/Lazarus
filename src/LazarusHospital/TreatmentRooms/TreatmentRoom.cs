using LazarusHospital.Conditions;
using LazarusHospital.Interfaces;
using LazarusHospital.TreatmentRooms.Machines;

namespace LazarusHospital.TreatmentRooms
{
    public class TreatmentRoom : Resource, IConditionVisistor
    {
        private TreatmentMachine TreatmentMachine { get; set; }

        public TreatmentRoom(string name, TreatmentMachine treatmentMachine)
            : base(name)
        {
            TreatmentMachine = treatmentMachine;
        }
        
        public bool CanTreatCondition(Flu condition)
        {
            return TreatmentMachine.CanTreatCondition(condition);
        }

        public bool CanTreatCondition(Cancer condition)
        {
            return TreatmentMachine.CanTreatCondition(condition);
        }
    }
}