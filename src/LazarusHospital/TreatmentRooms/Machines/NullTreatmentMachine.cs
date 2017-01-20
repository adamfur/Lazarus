using LazarusHospital.Conditions;

namespace LazarusHospital.TreatmentRooms.Machines
{
    public class NullTreatmentMachine : TreatmentMachine
    {
        public NullTreatmentMachine()
            : base(null)
        {
        }

        public override bool CanTreatCondition(Flu condition)
        {
            return true;
        }

        public override bool CanTreatCondition(Cancer condition)
        {
            return false;
        }
    }
}