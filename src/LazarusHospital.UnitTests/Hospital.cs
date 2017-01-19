using System;

namespace LazarusHospital.UnitTests
{
    public class Hospital
    {
        public void RegisterPatient(Patient patient)
        {

        }
    }

    public class Scheduler
    {

    }

    public interface IBookable
    {
    }

    public abstract class Resource
    {
        public string Name { get; private set; }

        public Resource(string name)
        {
            Name = name;
        }
    }

    public interface ICanTreat
    {
        bool CanTreat(Patient patient);
    }

    public abstract class Doctor : Resource, ICanTreat
    {
        protected Doctor(string name)
            : base(name)
        {
        }

        public abstract bool CanTreat(Patient patient);
    }

    public class Oncologist : Doctor
    {
        public Oncologist(string name)
            : base(name)
        {
        }

        public override bool CanTreat(Patient patient)
        {
            return patient.Condition.Visit(this);
        }        
    }

    public class GeneralPractitioner : Doctor
    {
        public GeneralPractitioner(string name)
            : base(name)
        {
        }

        public override bool CanTreat(Patient patient)
        {
            return patient.Condition.Visit(this);
        }        
    }

    public class TreatmentRoom : Resource, ICanTreat
    {
        public TreatmentMachine TreatmentMachine { get; set; }
        public TreatmentRoom(string name, TreatmentMachine treatmentMachine)
            : base(name)
        {
            TreatmentMachine = treatmentMachine;
        }

        public bool CanTreat(Patient patient)
        {
            return TreatmentMachine.CanTreat(patient);
        }
    }

    public abstract class TreatmentMachine : Resource, ICanTreat
    {
        protected TreatmentMachine(string name)
            : base(name)
        {
        }

        public abstract bool CanTreat(Patient patient);
    }

    public class AdvancedTreatmentMachine : TreatmentMachine
    {
        public AdvancedTreatmentMachine(string name)
            : base(name)
        {
        }
    }

    public class SimpleTreatmentMachine : TreatmentMachine
    {
        public SimpleTreatmentMachine(string name)
            : base(name)
        {
        }
    }

    public class Patient : Resource
    {
        public Condition Condition { get; set; }

        public Patient(string name, Condition condition)
            : base(name)
        {
            
        }
    }

    public abstract class Condition
    {
        public abstract bool Visit(Oncologist doctor);
        public abstract bool Visit(GeneralPractitioner doctor);
    }

    public class Flu : Condition
    {
        public override bool Visit(GeneralPractitioner doctor)
        {
            return true;
        }

        public override bool Visit(Oncologist doctor)
        {
            return false;
        }
    }

    public class Cancer : Condition
    {
        public Topology Topology { get; set; }
        public Cancer(Topology topology)
        {
            Topology = topology;
        }

        public override bool Visit(Oncologist doctor)
        {
            return false;
        }

        public override bool Visit(GeneralPractitioner doctor)
        {
            return true;
        }
    }

    public enum Topology
    {
        Head,
        Neck,
        Breast
    }

    public class SystemTime
    {
        public static Func<DateTime> Delegate = () => DateTime.Now;
        public DateTime Now => Delegate();
    }

    public class ConsultationRecord
    {
        public ConsultationRecord(Patient patient, Doctor doctor, TreatmentRoom treatmentRoom, DateTime registrationDate, DateTime consolutationDate)
        {
            
        }
    }
}