using System;

namespace LazarusHospital.UnitTests
{
    public class SystemTime
    {
        protected static Func<DateTime> Delegate = () => DateTime.Now;
        public static DateTime Now => Delegate();
    }

    public class SystemTimeMock : SystemTime
    {
        public static SetTimeDelegate(Func<DateTime> method)
        {
            Delegate = method;
        }
    }
}