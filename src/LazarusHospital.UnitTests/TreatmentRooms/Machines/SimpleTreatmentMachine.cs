namespace LazarusHospital.UnitTests.TreatmentRooms.Machines
{
    public class SimpleTreatmentMachine : TreatmentMachine
    {
        public SimpleTreatmentMachine(string name)
            : base(name)
        {
        }

        public override bool CanTreat(Patient patient)
        {
            return true;
            //return patient.Condition.Visit(this);
        }
    }
}