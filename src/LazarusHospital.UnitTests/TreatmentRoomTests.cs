using LazarusHospital.Conditions;
using LazarusHospital.Employee;
using LazarusHospital.TreatmentRooms;
using LazarusHospital.TreatmentRooms.Machines;
using Xunit;

namespace LazarusHospital.UnitTests
{
    public class TreatmentRoomTests
    {
        private Patient _patientWithCancerHead;
        private Patient _patientWithCancerNeck;
        private Patient _patientWithCancerBreast;
        private Patient _patientWithFlu;
        private TreatmentRoom _advancedTreatmentRoom;
        private TreatmentRoom _simpleTreatmentRoom;
        private TreatmentRoom _normalTreatmentRoom;

        public TreatmentRoomTests()
        {
            _patientWithCancerHead = new Patient("CancerHead", new Cancer(Topology.Head));
            _patientWithCancerNeck = new Patient("CancerHead", new Cancer(Topology.Neck));
            _patientWithCancerBreast = new Patient("CancerHead", new Cancer(Topology.Breast));
            _patientWithFlu = new Patient("Flu", new Flu());

            _advancedTreatmentRoom = new TreatmentRoom("Advanced", new AdvancedTreatmentMachine("AdvancedMachinery"));
            _simpleTreatmentRoom = new TreatmentRoom("Simple", new SimpleTreatmentMachine("SimpleMachinery"));
            _normalTreatmentRoom = new TreatmentRoom("Normal", new NullTreatmentMachine());
        }

        [Fact]
        public void Advanced_Treatment_Room_can_treat_patient_with_head_cancer()
        {
            
        }

        [Fact]
        public void Advanced_Treatment_Room_can_treat_patient_with_neck_cancer()
        {

        }

        [Fact]
        public void Advanced_Treatment_Room_can_not_treat_patient_with_breast_cancer()
        {

        }

        [Fact]
        public void Advanced_Treatment_Room_can_not_treat_patient_with_flu()
        {

        }
    }
}