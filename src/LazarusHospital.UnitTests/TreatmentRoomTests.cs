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
            _patientWithCancerNeck = new Patient("CancerNeck", new Cancer(Topology.Neck));
            _patientWithCancerBreast = new Patient("CancerBreast", new Cancer(Topology.Breast));
            _patientWithFlu = new Patient("Flu", new Flu());

            _advancedTreatmentRoom = new TreatmentRoom("Advanced", new AdvancedTreatmentMachine("AdvancedMachinery"));
            _simpleTreatmentRoom = new TreatmentRoom("Simple", new SimpleTreatmentMachine("SimpleMachinery"));
            _normalTreatmentRoom = new TreatmentRoom("Normal", new NullTreatmentMachine());
        }

        [Fact]
        public void Advanced_Treatment_Room_can_treat_patient_with_head_cancer()
        {
            var result = _patientWithCancerHead.CanBeTreatedBy(_advancedTreatmentRoom);

            Assert.True(result);
        }

        [Fact]
        public void Advanced_Treatment_Room_can_treat_patient_with_neck_cancer()
        {
            var result = _patientWithCancerNeck.CanBeTreatedBy(_advancedTreatmentRoom);

            Assert.True(result);
        }

        [Fact]
        public void Advanced_Treatment_Room_can_treat_patient_with_breast_cancer()
        {
            var result = _patientWithCancerBreast.CanBeTreatedBy(_advancedTreatmentRoom);

            Assert.True(result);
        }

        [Fact]
        public void Advanced_Treatment_Room_can_not_treat_patient_with_flu()
        {
            var result = _patientWithFlu.CanBeTreatedBy(_advancedTreatmentRoom);

            Assert.False(result);
        }

        [Fact]
        public void Simple_Treatment_Room_can_not_treat_patient_with_head_cancer()
        {
            var result = _patientWithCancerHead.CanBeTreatedBy(_simpleTreatmentRoom);

            Assert.False(result);            
        }

        [Fact]
        public void Simple_Treatment_Room_can_not_treat_patient_with_neck_cancer()
        {
            var result = _patientWithCancerNeck.CanBeTreatedBy(_simpleTreatmentRoom);

            Assert.False(result);      
        }

        [Fact]
        public void Simple_Treatment_Room_can_treat_patient_with_breast_cancer()
        {
            var result = _patientWithCancerBreast.CanBeTreatedBy(_simpleTreatmentRoom);

            Assert.True(result);      
        }

        [Fact]
        public void Simple_Treatment_Room_can_not_treat_patient_with_flu()
        {
            var result = _patientWithFlu.CanBeTreatedBy(_simpleTreatmentRoom);

            Assert.False(result);      
        }        

        [Fact]
        public void Normal_Treatment_Room_can_not_treat_patient_with_head_cancer()
        {
            var result = _patientWithCancerHead.CanBeTreatedBy(_normalTreatmentRoom);

            Assert.False(result);                  
        }

        [Fact]
        public void Normal_Treatment_Room_can_not_treat_patient_with_neck_cancer()
        {
            var result = _patientWithCancerNeck.CanBeTreatedBy(_normalTreatmentRoom);

            Assert.False(result);      
        }

        [Fact]
        public void Normal_Treatment_Room_can_not_treat_patient_with_breast_cancer()
        {
            var result = _patientWithCancerBreast.CanBeTreatedBy(_normalTreatmentRoom);

            Assert.False(result);      
        }

        [Fact]
        public void Normal_Treatment_Room_can_treat_patient_with_flu()
        {
            var result = _patientWithFlu.CanBeTreatedBy(_normalTreatmentRoom);

            Assert.True(result);      
        }   
    }
}