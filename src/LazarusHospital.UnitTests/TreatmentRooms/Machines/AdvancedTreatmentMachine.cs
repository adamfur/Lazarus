namespace LazarusHospital.UnitTests.TreatmentRooms.Machines
{
    public class AdvancedTreatmentMachine : TreatmentMachine
    {
        public AdvancedTreatmentMachine(string name)
            : base(name)
        {
        }

        public override bool CanTreat(Patient patient)
        {
            return patient.Condition.Visit(this);
        }
    }
}