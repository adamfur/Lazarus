using System;
using System.Collections.Generic;
using LazarusHospital.UnitTests.Employee;
using LazarusHospital.UnitTests.Employee.Roles;
using LazarusHospital.UnitTests.TreatmentRooms;
using LazarusHospital.UnitTests.TreatmentRooms.Machines;

namespace LazarusHospital.UnitTests
{
    public class Hospital
    {
        private List<TreatmentRoom> _treatmentRooms = new List<TreatmentRoom>();
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Patient> _registeredPatients = new List<Patient>();
        private List<ConsultationRecord> _records = new List<ConsultationRecord>();

        public Hospital()
        {
            AddDoctor(new Doctor("John", new Role[] { new Oncologist() }));
            AddDoctor(new Doctor("Anna", new Role[] { new GeneralPractitioner() } ));
            AddDoctor(new Doctor("Peter", new Role[] { new Oncologist(), new GeneralPractitioner() } ));
            AddRoom(new TreatmentRoom("One", new AdvancedTreatmentMachine("Elekta")));
            AddRoom(new TreatmentRoom("Two", new AdvancedTreatmentMachine("Varian")));
            AddRoom(new TreatmentRoom("Three", new SimpleTreatmentMachine("MM50")));
            AddRoom(new TreatmentRoom("Four", new NullTreatmentMachine()));
            AddRoom(new TreatmentRoom("Five", new NullTreatmentMachine()));
        }

        private void AddDoctor(Doctor doctor)
        {
            _doctors.Add(doctor);
        }

        private void AddRoom(TreatmentRoom treatmentRoom)
        {
            _treatmentRooms.Add(treatmentRoom);
        }

        public void RegisterPatient(Patient patient)
        {
        }

        public IEnumerable<Patient> ListRegisteredPatients()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConsultationRecord> ListScheduledConsultations()
        {
            throw new NotImplementedException();
        }
    }
}