using System;
using LazarusHospital.Conditions;
using Xunit;

namespace LazarusHospital.UnitTests
{
    [Collection("MockTime")]
    public class BookingTests
    {
        private Patient _patientWithCancerHead;
        private Patient _patientWithCancerNeck;
        private Patient _patientWithCancerBreast;
        private Patient _patientWithFlu;

        private Hospital _hospital;

        public BookingTests()
        {
            _patientWithCancerHead = new Patient("CancerHead", new Cancer(Topology.Head));
            _patientWithCancerNeck = new Patient("CancerNeck", new Cancer(Topology.Neck));
            _patientWithCancerBreast = new Patient("CancerBreast", new Cancer(Topology.Breast));
            _patientWithFlu = new Patient("Flu", new Flu());
            
            _hospital = new Hospital(new Scheduler());
            _hospital.LoadHospitalDefaultResources();
        }

        [Fact]
        public void Book_a_consultation_is_not_assigned_to_the_same_day()
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
    }
}