using System;

namespace LazarusHospital.UnitTests
{
    public class SystemTime
    {
        public static Func<DateTime> Delegate = () => DateTime.Now;
        public DateTime Now => Delegate();
    }
}