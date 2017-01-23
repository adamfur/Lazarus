using System;

namespace LazarusHospital
{
    public class SystemTimeMock : SystemTime
    {
        public static void SetTimeDelegate(Func<DateTime> method)
        {
            Delegate = method;
        }
    }
}