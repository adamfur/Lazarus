using System;
using System.Collections.Generic;
using LazarusHospital.Employee;
using LazarusHospital.Employee.Roles;
using LazarusHospital.TreatmentRooms;
using LazarusHospital.TreatmentRooms.Machines;

namespace LazarusHospital
{
    public class Hospital
    {
        private IList<TreatmentRoom> _treatmentRooms = new List<TreatmentRoom>();
        private IList<Doctor> _doctors = new List<Doctor>();
        private IList<Patient> _registeredPatients = new List<Patient>();
        private IList<ConsultationRecord> _records = new List<ConsultationRecord>();
        private ISet<string> _registeredNames = new HashSet<string>();
        private IScheduler _scheduler;

        public Hospital(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public void LoadHospitalDefaultResources()
        {
            AddDoctor(new Doctor("John", new Role[] { new Oncologist() }));
            AddDoctor(new Doctor("Anna", new Role[] { new GeneralPractitioner() }));
            AddDoctor(new Doctor("Peter", new Role[] { new Oncologist(), new GeneralPractitioner() }));
            AddTreatmentRoom(new TreatmentRoom("One", new AdvancedTreatmentMachine("Elekta")));
            AddTreatmentRoom(new TreatmentRoom("Two", new AdvancedTreatmentMachine("Varian")));
            AddTreatmentRoom(new TreatmentRoom("Three", new SimpleTreatmentMachine("MM50")));
            AddTreatmentRoom(new TreatmentRoom("Four", new NullTreatmentMachine()));
            AddTreatmentRoom(new TreatmentRoom("Five", new NullTreatmentMachine()));
        }

        public void AddDoctor(Doctor doctor)
        {
            AddName(doctor);
            _doctors.Add(doctor);
        }

        public void AddTreatmentRoom(TreatmentRoom treatmentRoom)
        {
            AddName(treatmentRoom);
            _treatmentRooms.Add(treatmentRoom);
        }

        public ConsultationRecord RegisterPatient(Patient patient)
        {
            var appointment = _scheduler.ScheduleConsultation(patient, _doctors, _treatmentRooms);
            AddName(patient);
            _registeredPatients.Add(patient);
            return appointment;
        }

        private void AddName(Resource resource)
        {
            var name = resource.Name;

            if (_registeredNames.Contains(name))
            {
                throw new Exception($"Name: {name} has already been used!");
            }
            _registeredNames.Add(name);
        }

        public IEnumerable<Patient> ListRegisteredPatients()
        {
            return _registeredPatients;
        }

        public IEnumerable<ConsultationRecord> ListScheduledConsultations()
        {
            return _scheduler.ListScheduledConsultations();
        }
    }
}