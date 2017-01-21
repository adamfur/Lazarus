using System;
using System.Collections.Generic;
using System.Linq;
using LazarusHospital.Conditions;
using LazarusHospital.Employee;
using LazarusHospital.Employee.Roles;
using LazarusHospital.TreatmentRooms;
using LazarusHospital.TreatmentRooms.Machines;
using NSubstitute;
using Xunit;

namespace LazarusHospital.UnitTests
{
    public class HospitalTests
    {
        private Patient _patientWithFlu;
        private Hospital _hospital;
        private IScheduler _scheduler;
        private TreatmentRoom _normalTreatmentRoom;
        private Doctor _generalPractitioner;
        
        public HospitalTests()
        {
            _generalPractitioner = new Doctor("GeneralPractitioner", new Role[] { new GeneralPractitioner() });
            _patientWithFlu = new Patient("Flu", new Flu());
            _scheduler = Substitute.For<IScheduler>();
            _hospital = new Hospital(_scheduler);
            _normalTreatmentRoom = new TreatmentRoom("Normal", new NullTreatmentMachine());
        }

        [Fact]
        public void ListRegisteredPatients_returns_inserted_patients()
        {
            // Arrange
            _hospital.RegisterPatient(_patientWithFlu);

            // Act
            var result = _hospital.ListRegisteredPatients().ToList();

            // Assert
            Assert.Equal(1, result.Count);
            Assert.True(result.Contains(_patientWithFlu));
        }

        [Fact]
        public void ListScheduledConsultations_is_dispatched_to_scheduler()
        {
            // Arrange
            IEnumerable<ConsultationRecord> enumeration = new List<ConsultationRecord>();
            _scheduler.ListScheduledConsultations().Returns(enumeration);

            // Act
            var result = _hospital.ListScheduledConsultations();

            // Assert
            Assert.Same(enumeration, result);
            _scheduler.Received().ListScheduledConsultations();
        }

        [Fact]
        public void RegisterPatient_throw_if_no_available_resource_is_found()
        {
            // Arrange
            _hospital = new Hospital(new Scheduler());

            // Act

            // Assert
            Assert.Throws<NoTreatmentResourcesForPatientException>(() => _hospital.RegisterPatient(_patientWithFlu));
        }

        [Fact]
        public void RegisterPatient_throw_if_no_doctor_is_found()
        {
            // Arrange
            _hospital = new Hospital(new Scheduler());
            _hospital.AddTreatmentRoom(_normalTreatmentRoom);

            // Act

            // Assert
            Assert.Throws<NoTreatmentResourcesForPatientException>(() => _hospital.RegisterPatient(_patientWithFlu));
        }     

        [Fact]
        public void RegisterPatient_throw_if_no_treatment_room_is_found()
        {
            // Arrange
            _hospital = new Hospital(new Scheduler());
            _hospital.AddDoctor(_generalPractitioner);

            // Act

            // Assert
            Assert.Throws<NoTreatmentResourcesForPatientException>(() => _hospital.RegisterPatient(_patientWithFlu));
        }              

        [Fact]
        public void Verify_throw_if_duplicated_doctor_name_is_inserted()
        {
            // Arrange
            _hospital.AddDoctor(_generalPractitioner);

            // Act

            // Assert
            Assert.Throws<Exception>(() => _hospital.AddDoctor(_generalPractitioner));
        }

        [Fact]
        public void Verify_throw_if_duplicated_treatment_rooms_name_is_inserted()
        {
            // Arrange
            _hospital.AddTreatmentRoom(_normalTreatmentRoom);

            // Act

            // Assert
            Assert.Throws<Exception>(() => _hospital.AddTreatmentRoom(_normalTreatmentRoom));
        }        

        [Fact]
        public void Verify_throw_if_duplicated_patient_name_is_inserted()
        {
            // Arrange
            _hospital = new Hospital(new Scheduler());
            _hospital.AddDoctor(_generalPractitioner);            
            _hospital.AddTreatmentRoom(_normalTreatmentRoom);
            _hospital.RegisterPatient(_patientWithFlu);

            // Act

            // Assert
            Assert.Throws<Exception>(() => _hospital.RegisterPatient(_patientWithFlu));
        }           
    }
}