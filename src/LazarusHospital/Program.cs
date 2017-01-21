using System;
using LazarusHospital.Conditions;

namespace LazarusHospital
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hospital = new Hospital(new Scheduler());

            hospital.LoadHospitalDefaultResources();
            PrintWelcome();

            while (true)
            {
                PrintMenu();
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        string name = ReadName();
                        Condition condition = ReadCondition();

                        try
                        {
                            var consultationRecord = hospital.RegisterPatient(new Patient(name, condition));

                            Console.WriteLine("Done!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "2":
                        PrintAllPatientRecords(hospital);
                        break;
                    case "3":
                        PrintAllConsultationRecords(hospital);
                        break;
                    default:
                        Console.WriteLine($"Unknown command: {input}!");
                        break;

                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static void PrintWelcome()
        {
            Console.WriteLine("Welcome to the Lazarus Hospital user interface!");
            Console.WriteLine();
        }

        private static int PrintAllConsultationRecords(Hospital hospital)
        {
            var index = 1;

            Console.WriteLine("Printing all consultation records!");
            foreach (var record in hospital.ListScheduledConsultations())
            {
                Console.WriteLine($"{index++}: Patient: {record.Patient}, Doctor: {record.Doctor.Name}, Treatment Room: {record.TreatmentRoom.Name}, Registration Date: {record.RegistrationDate:yyyy-MM-dd}, Consolutation Date: {record.ConsolutationDate:yyyy-MM-dd}");
            }

            return index;
        }

        private static int PrintAllPatientRecords(Hospital hospital)
        {
            var index = 1;

            Console.WriteLine("Printing all patient records!");
            foreach (var patient in hospital.ListRegisteredPatients())
            {
                Console.WriteLine($"{index++}: Patient: {patient.Name}");
            }

            return index;
        }

        private static Condition ReadCondition()
        {
            while (true)
            {
                PrintConditionMenu();

                var selectedCondition = Console.ReadLine();

                switch (selectedCondition)
                {
                    case "1":
                        return new Cancer(Topology.Head);
                    case "2":
                        return new Cancer(Topology.Neck);
                    case "3":
                        return new Cancer(Topology.Breast);
                    case "4":
                        return new Flu();
                }
            }
        }

        private static void PrintConditionMenu()
        {
            Console.WriteLine("Conditions:");
            Console.WriteLine("1) Cancer Head");
            Console.WriteLine("2) Cancer Neck");
            Console.WriteLine("3) Cancer Breast");
            Console.WriteLine("4) Flu");
        }

        private static string ReadName()
        {
            string name;

            do
            {
                Console.Write("Patient name: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));
            return name;
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1) Patient registration");
            Console.WriteLine("2) Get the list of registered patients");
            Console.WriteLine("3) Get the list of scheduled consultations");
        }
    }
}
