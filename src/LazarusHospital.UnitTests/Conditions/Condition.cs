using LazarusHospital.UnitTests.Employee.Roles;
using LazarusHospital.UnitTests.TreatmentRooms.Machines;

namespace LazarusHospital.UnitTests.Conditions
{
    public abstract class Condition
    {
        public abstract bool Visit(Oncologist doctor);
        public abstract bool Visit(GeneralPractitioner doctor);
        public abstract bool Visit(AdvancedTreatmentMachine treatmentMachine);
        public abstract bool Visit(SimpleTreatmentMachine treatmentMachine);
        public abstract bool Visit(NullTreatmentMachine treatmentMachine);
    }
}