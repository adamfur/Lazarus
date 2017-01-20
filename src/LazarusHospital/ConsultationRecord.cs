using System;
using LazarusHospital.Employee;
using LazarusHospital.TreatmentRooms;

namespace LazarusHospital
{
    public class ConsultationRecord
    {
        public Patient Patient { get; }
        public Doctor Doctor { get; }
        public TreatmentRoom TreatmentRoom { get; }
        public DateTime RegistrationDate { get; }
        public DateTime ConsolutationDate { get; }

        public ConsultationRecord(Patient patient, Doctor doctor, TreatmentRoom treatmentRoom, DateTime registrationDate, DateTime consolutationDate)
        {
            Patient = patient;
            Doctor = doctor;
            TreatmentRoom = treatmentRoom;
            RegistrationDate = registrationDate;
            ConsolutationDate = consolutationDate;
        }
    }
}