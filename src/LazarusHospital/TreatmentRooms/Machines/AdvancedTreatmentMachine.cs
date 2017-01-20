using LazarusHospital.Conditions;

namespace LazarusHospital.TreatmentRooms.Machines
{
    public class AdvancedTreatmentMachine : TreatmentMachine
    {
        public AdvancedTreatmentMachine(string name)
            : base(name)
        {
        }

        public override bool CanTreatCondition(Flu condition)
        {
            return false;
        }

        public override bool CanTreatCondition(Cancer condition)
        {
            return true;
        }
    }
}