using System;
using System.Collections.Generic;
using System.Linq;

namespace LazarusHospital.UnitTests
{
    public class Hospital
    {
        public Hospital()
        {
            AddDoctor(new Doctor("John", new Role[] { new Oncologist() }));
            AddDoctor(new Doctor("Anna", new Role[] { new GeneralPractitioner() } ));
            AddDoctor(new Doctor("Peter", new Role[] { new Oncologist(), new GeneralPractitioner() } ));

            var elekta = new AdvancedTreatmentMachine("Elekta");
            var varian = new AdvancedTreatmentMachine("Varian");
            var mm50 = new SimpleTreatmentMachine("MM50");
            var none = new NullTreatmentMachine();

            AddRoom(new TreatmentRoom("One", elekta));
            AddRoom(new TreatmentRoom("Two", varian));
            AddRoom(new TreatmentRoom("Three", mm50));
            AddRoom(new TreatmentRoom("Four", none));
            AddRoom(new TreatmentRoom("Five", none));
            
        }

        private void AddDoctor(Doctor doctor)
        {

        }

        private void AddRoom(TreatmentRoom room)
        {

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

    public class Doctor : Resource, ICanTreat
    {
        private Role[] Roles { get; set; }

        public Doctor(string name, Role[] roles)
            : base(name)
        {
            Roles = roles;
        }

        public bool CanTreat(Patient patient)
        {
            return Roles.Any(r => r.CanTreat(patient));
        }
    }

    public abstract class Role : ICanTreat
    {
        public abstract bool CanTreat(Patient patient);
    }

    public class Oncologist : Role
    {
        public override bool CanTreat(Patient patient)
        {
            return patient.Condition.Visit(this);
        }        
    }

    public class GeneralPractitioner : Role
    {
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

        public override bool CanTreat(Patient patient)
        {
            return patient.Condition.Visit(this);
        }
    }

    public class SimpleTreatmentMachine : TreatmentMachine
    {
        public SimpleTreatmentMachine(string name)
            : base(name)
        {
        }

        public override bool CanTreat(Patient patient)
        {
            return patient.Condition.Visit(this);
        }
    }

    public class NullTreatmentMachine : TreatmentMachine
    {
        public NullTreatmentMachine()
            : base(null)
        {
        }

        public override bool CanTreat(Patient patient)
        {
            return patient.Condition.Visit(this);
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
        public abstract bool Visit(AdvancedTreatmentMachine treatmentMachine);
        public abstract bool Visit(SimpleTreatmentMachine treatmentMachine);
        public abstract bool Visit(NullTreatmentMachine treatmentMachine);
    }

    public class Flu : Condition
    {
        public override bool Visit(AdvancedTreatmentMachine treatmentMachine)
        {
            return false;
        }

        public override bool Visit(NullTreatmentMachine treatmentMachine)
        {
            return true;
        }

        public override bool Visit(SimpleTreatmentMachine treatmentMachine)
        {
            return false;
        }

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

        public override bool Visit(AdvancedTreatmentMachine treatmentMachine)
        {
            switch (Topology)
            {
                 case Topology.Head:
                 case Topology.Neck:
                    return true;
                 default:
                    return false;
            }
        }

        public override bool Visit(SimpleTreatmentMachine treatmentMachine)
        {
            return Topology == Topology.Breast;
        }

        public override bool Visit(NullTreatmentMachine treatmentMachine)
        {
            return false;
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