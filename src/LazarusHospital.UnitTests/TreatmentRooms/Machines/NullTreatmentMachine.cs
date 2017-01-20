namespace LazarusHospital.UnitTests.TreatmentRooms.Machines
{
    public class NullTreatmentMachine : TreatmentMachine
    {
        public NullTreatmentMachine()
            : base(null)
        {
        }

        public override bool CanTreat(Patient patient)
        {
            return true;
            //return patient.Condition.Visit(this);
        }
    }
}