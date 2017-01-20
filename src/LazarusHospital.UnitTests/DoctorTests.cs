using LazarusHospital.Conditions;
using LazarusHospital.Employee;
using LazarusHospital.Employee.Roles;
using Xunit;

namespace LazarusHospital.UnitTests
{
    public class DoctorTests
    {
        private Doctor _oncologist;
        private Patient _patientWithCancer;
        private Patient _patientWithFlu;
        private Doctor _generalPractitioner;
        private Doctor _multiPurposeDoctor;

        public DoctorTests()
        {
            _oncologist = new Doctor("Oncologist", new Role[] { new Oncologist() });
            _generalPractitioner = new Doctor("GeneralPractitioner", new Role[] { new GeneralPractitioner() });
            _multiPurposeDoctor = new Doctor("MultiPurposeDoctor", new Role[] { new Oncologist(), new GeneralPractitioner() });
            _patientWithCancer = new Patient("Cancer", new Cancer(Topology.Head));
            _patientWithFlu = new Patient("Flu", new Flu());
        }

        [Fact]
        public void Oncologist_can_treat_patient_with_cancer()
        {
            var result = _patientWithCancer.CanBeTreatedBy(_oncologist);

            Assert.True(result);
        }

        [Fact]
        public void Oncologist_can_not_treat_patient_with_flu()
        {
            var result = _patientWithFlu.CanBeTreatedBy(_oncologist);

            Assert.False(result);
        }

        [Fact]
        public void General_practitioner_can_not_treat_patient_with_cancer()
        {
            var result = _patientWithCancer.CanBeTreatedBy(_generalPractitioner);

            Assert.False(result);
        }

        [Fact]
        public void General_practitioner_can_treat_patient_with_flu()
        {
            var result = _patientWithFlu.CanBeTreatedBy(_generalPractitioner);

            Assert.True(result);
        }

        [Fact]
        public void Multi_purpose_doctor_can_treat_patient_with_flu()
        {
            var result = _patientWithCancer.CanBeTreatedBy(_multiPurposeDoctor);

            Assert.True(result);
        }

        [Fact]
        public void Multi_purpose_doctor_can_treat_patient_with_cancer()
        {
            var result = _patientWithFlu.CanBeTreatedBy(_multiPurposeDoctor);

            Assert.True(result);
        }
    }
}