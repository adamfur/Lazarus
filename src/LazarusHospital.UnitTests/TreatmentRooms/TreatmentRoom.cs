using LazarusHospital.UnitTests.Conditions;
using LazarusHospital.UnitTests.Interfaces;
using LazarusHospital.UnitTests.TreatmentRooms.Machines;

namespace LazarusHospital.UnitTests.TreatmentRooms
{
    public class TreatmentRoom : Resource, IConditionVisistor
    {
        private TreatmentMachine TreatmentMachine { get; set; }

        public TreatmentRoom(string name, TreatmentMachine treatmentMachine)
            : base(name)
        {
            TreatmentMachine = treatmentMachine;
        }
        
        public bool Visit(Flu condition)
        {
            return TreatmentMachine.Visit(condition);
        }

        public bool Visit(Cancer condition)
        {
            return TreatmentMachine.Visit(condition);
        }
    }
}