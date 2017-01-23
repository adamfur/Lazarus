using System;
using System.IO;
using System.Linq;
using CsvHelper;
using LazarusHospital.Conditions;

namespace LazarusHospital
{
    public class Program
    {
        private Hospital _hospital = new Hospital(new Scheduler());

        public static void Main(string[] args)
        {
            PrintWelcomeMessage();

            if (args.Length == 0)
            {
                Console.WriteLine("No input files selected!");
                return;
            }

            new Program().Run(args);
        }

        private void Run(string[] files)
        {
            _hospital.LoadHospitalDefaultResources();

            foreach (var filename in files)
            {
                LoadPatientFile(filename);
            }
        }

        private void LoadPatientFile(string filename)
        {
            try
            {
                using (var reader = File.OpenText(filename))
                {
                    var csvReader = new CsvReader(reader);
                    csvReader.Configuration.Delimiter = ",";
                    var batch = csvReader.GetRecords<PatientCsvBatchRecord>().ToList();

                    foreach (var row in batch)
                    {
                        try
                        {
                            var condition = ConditionFactory.Create(row.Condition);
                            var patient = new Patient(row.Name, condition);
                            var consultationRecord = _hospital.RegisterPatient(patient);

                            Console.WriteLine(consultationRecord);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Lazarus Hospital scheduling application!");
            Console.WriteLine();
        }
    }
}
