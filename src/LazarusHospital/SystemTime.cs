using System;

namespace LazarusHospital
{
    public class SystemTime
    {
        protected static Func<DateTime> Delegate = () => DateTime.Now;
        public static DateTime Now => Delegate();
    }

    public class SystemTimeMock : SystemTime
    {
        public static void SetTimeDelegate(Func<DateTime> method)
        {
            Delegate = method;
        }
    }
}