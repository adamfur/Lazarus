using System.Collections.Generic;
using System.Linq;
using LazarusHospital.Employee;
using LazarusHospital.TreatmentRooms;

namespace LazarusHospital
{
    public class Scheduler : IScheduler
    {
        private IList<ConsultationRecord> _records = new List<ConsultationRecord>();

        public IEnumerable<ConsultationRecord> ListScheduledConsultations()
        {
            return _records;
        }

        public ConsultationRecord ScheduleConsultation(Patient patient, IList<Doctor> doctors, IList<TreatmentRoom> treatmentRooms)
        {
            VerifyThatResourcesExist(patient, doctors, treatmentRooms);
            var tomorrow = SystemTime.Now.Date.AddDays(1);

            for (var date = tomorrow; ; date = date.AddDays(1))
            {
                var availableDoctor = doctors.FirstOrDefault(d => patient.CanBeTreatedBy(d) && !_records.Any(r => r.Doctor == d && r.ConsolutationDate == date));
                var availableTreatmentRoom = treatmentRooms.FirstOrDefault(t => patient.CanBeTreatedBy(t) && !_records.Any(r => r.TreatmentRoom == t && r.ConsolutationDate == date));

                if (availableDoctor == null || availableTreatmentRoom == null)
                {
                    continue;
                }

                var record = new ConsultationRecord(patient, availableDoctor, availableTreatmentRoom, SystemTime.Now, date);

                _records.Add(record);
                return record;
            }
        }

        private void VerifyThatResourcesExist(Patient patient, IList<Doctor> doctors, IList<TreatmentRoom> treatmentRooms)
        {
            if (!doctors.Any(d => patient.CanBeTreatedBy(d)) || !treatmentRooms.Any(t => patient.CanBeTreatedBy(t)))
            {
                throw new NoTreatmentResourcesForPatientException($"No missing treatment resources for {patient}");
            }
        }
    }
}