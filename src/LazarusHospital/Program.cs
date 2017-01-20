using System;
using LazarusHospital.Conditions;

namespace LazarusHospital
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hospital = new Hospital(new Scheduler());

            Console.WriteLine("Welcome to the Lazarus Hospital user interface!");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Patient registration");
                Console.WriteLine("2) Get the list of registered patients");
                Console.WriteLine("3) Get the list of scheduled consultations");

                var input = Console.ReadLine();
                var index = 1;

                switch (input)
                {
                    case "1":
                        string name = null;
                        Condition condition = null;

                        do
                        {
                            Console.Write("Patient name: ");
                            name = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(name));

                        do
                        {
                            Console.WriteLine("Conditions:");
                            Console.WriteLine("1) Cancer Head");
                            Console.WriteLine("2) Cancer Neck");
                            Console.WriteLine("3) Cancer Breast");
                            Console.WriteLine("4) Flu");

                            var selectedCondition = Console.ReadLine();

                            switch (selectedCondition)
                            {
                                case "1":
                                    condition = new Cancer(Topology.Head);
                                    break;
                                case "2":
                                    condition = new Cancer(Topology.Neck);
                                    break;
                                case "3":
                                    condition = new Cancer(Topology.Breast);
                                    break;
                                case "4":
                                    condition = new Flu();
                                    break;
                            }

                        } while (condition == null);

                        var consultation = hospital.RegisterPatient(new Patient(name, condition));
                        
                        Console.WriteLine("Done!");

                        break;
                    case "2":
                        Console.WriteLine("Printing all patient records!");
                        foreach (var patient in hospital.ListRegisteredPatients())
                        {
                            Console.WriteLine($"{index++}: Patient: {patient.Name}");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Printing all consultation records!");
                        foreach (var record in hospital.ListScheduledConsultations())
                        {
                            Console.WriteLine($"{index++}: Patient: {record.Patient}, Doctor: {record.Doctor.Name}, Treatment Room: {record.TreatmentRoom.Name}, Registration Date: {record.RegistrationDate:yyyy-MM-dd}, Consolutation Date: {record.ConsolutationDate:yyyy-MM-dd}");
                        }
                        break;
                    default:
                        Console.WriteLine($"Unknown command: {input}!");
                        break;

                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
