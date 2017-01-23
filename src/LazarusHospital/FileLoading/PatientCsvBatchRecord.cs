using System;
using System.IO;
using System.Linq;
using CsvHelper;
using LazarusHospital.Conditions;

namespace LazarusHospital
{
    public class PatientCsvBatchRecord
    {
        public string Name { get; set; }
        public string Condition { get; set; }
    }
}

