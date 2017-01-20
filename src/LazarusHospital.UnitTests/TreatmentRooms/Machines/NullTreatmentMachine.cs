using System;
using LazarusHospital.UnitTests.Conditions;

namespace LazarusHospital.UnitTests.TreatmentRooms.Machines
{
    public class NullTreatmentMachine : TreatmentMachine
    {
        public NullTreatmentMachine()
            : base(null)
        {
        }

        public override bool Visit(Flu condition)
        {
            return true;
        }

        public override bool Visit(Cancer condition)
        {
            return false;
        }
    }
}