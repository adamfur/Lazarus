using System;

namespace LazarusHospital
{
    public class NoTreatmentResourcesForPatientException : Exception
    {
        public NoTreatmentResourcesForPatientException(string message)
            : base(message)
        {
        }
    }
}