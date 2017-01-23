using System;
using LazarusHospital.Conditions;
using LazarusHospital.Employee;
using LazarusHospital.Employee.Roles;
using LazarusHospital.TreatmentRooms;
using LazarusHospital.TreatmentRooms.Machines;
using Xunit;

            // AddDoctor(new Doctor("John", new Role[] { new Oncologist() }));
            // AddDoctor(new Doctor("Anna", new Role[] { new GeneralPractitioner() }));
            // AddDoctor(new Doctor("Peter", new Role[] { new Oncologist(), new GeneralPractitioner() }));
            // AddTreatmentRoom(new TreatmentRoom("One", new AdvancedTreatmentMachine("Elekta")));
            // AddTreatmentRoom(new TreatmentRoom("Two", new AdvancedTreatmentMachine("Varian")));
            // AddTreatmentRoom(new TreatmentRoom("Three", new SimpleTreatmentMachine("MM50")));
            // AddTreatmentRoom(new TreatmentRoom("Four", new NullTreatmentMachine()));
            // AddTreatmentRoom(new TreatmentRoom("Five", new NullTreatmentMachine()));

namespace LazarusHospital.UnitTests
{
    [Collection("MockTime")]
    public class BookingTests
    {
        private Patient _patientWithCancerHead;
        private Patient _patientWithCancerNeck;
        private Patient _patientWithCancerBreast;
        private Patient _patientWithFlu;
        private Patient _anotherPatientWithFlu;
        private Hospital _hospital;

        public BookingTests()
        {
            _patientWithFlu = CreatePatientWithFlu("Flu");
            _anotherPatientWithFlu = new Patient("Bad Flu", new Flu());
            
            _hospital = new Hospital(new Scheduler());
            _hospital.AddTreatmentRoom(new TreatmentRoom("Flu One", new NullTreatmentMachine()));
            _hospital.AddDoctor(new Doctor("Anna", new Role[] { new GeneralPractitioner() }));
        }

        private Patient CreatePatientWithFlu(string name)
        {
            return new Patient(name, new Flu());
        }

        [Fact]
        public void Booking_a_consultation_is_not_assigned_to_the_same_day()
        {
            // Arrange
            var now = new DateTime(2000, 1, 1);
            SystemTimeMock.SetTimeDelegate(() => now);

            // Act
            var record = _hospital.RegisterPatient(_patientWithFlu);

            // Assert
            Assert.Equal(now, record.RegistrationDate);
            Assert.Equal(now.Date.AddDays(1), record.ConsolutationDate);
        }

        [Fact]
        public void Booking_two_available_resources_can_not_be_booked_the_same_day()
        {
            // Arrange
            var now = new DateTime(2000, 1, 1);
            SystemTimeMock.SetTimeDelegate(() => now);

            var patient1 = CreatePatientWithFlu("patient1");
            var patient2 = CreatePatientWithFlu("patient2");

            // Act
            var record1 = _hospital.RegisterPatient(patient1);
            var record2 = _hospital.RegisterPatient(patient2);

            // Assert
            Assert.Equal(now, record1.RegistrationDate);
            Assert.Equal(now.Date.AddDays(1), record1.ConsolutationDate);

            Assert.Equal(now, record2.RegistrationDate);
            Assert.Equal(now.Date.AddDays(2), record2.ConsolutationDate);
        }        
    }
}