using System;
using System.Collections.Generic;
using System.Linq;
using LazarusHospital.Employee;
using LazarusHospital.TreatmentRooms;

namespace LazarusHospital
{
    public class Scheduler
    {
        private IList<ConsultationRecord> _records = new List<ConsultationRecord>();

        public IEnumerable<ConsultationRecord> ListScheduledConsultations()
        {
            return _records;
        }

        public void BookConsultation(Patient patient, IList<Doctor> doctors, IList<TreatmentRoom> treatmentRooms)
        {
            var tomorrow = SystemTime.Now.Date.AddDays(1);

            for (var day = tomorrow; ; day = day.AddDays(1))
            {
                var availableDoctors = doctors.FirstOrDefault(d => patient.CanBeTreatedBy(d) && _records.Any(r => r.));
                //var availableRooms;
            }
        }
    }
}