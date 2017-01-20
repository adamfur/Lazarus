using System;
using LazarusHospital.UnitTests.Conditions;

namespace LazarusHospital.UnitTests.TreatmentRooms.Machines
{
    public class SimpleTreatmentMachine : TreatmentMachine
    {
        public SimpleTreatmentMachine(string name)
            : base(name)
        {
        }

        public override bool CanTreatCondition(Flu condition)
        {
            return false;
        }

        public override bool CanTreatCondition(Cancer condition)
        {
            return condition.Topology == Topology.Breast;
        }
    }
}