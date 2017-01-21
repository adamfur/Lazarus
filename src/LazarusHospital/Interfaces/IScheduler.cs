using System.Collections.Generic;
using LazarusHospital.Employee;
using LazarusHospital.TreatmentRooms;

namespace LazarusHospital
{
    public interface IScheduler
    {
        IEnumerable<ConsultationRecord> ListScheduledConsultations();
        ConsultationRecord ScheduleConsultation(Patient patient, IList<Doctor> doctors, IList<TreatmentRoom> treatmentRooms);
    }
}