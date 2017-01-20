using System;
using LazarusHospital.UnitTests.Conditions;

namespace LazarusHospital.UnitTests.TreatmentRooms.Machines
{
    public class AdvancedTreatmentMachine : TreatmentMachine
    {
        public AdvancedTreatmentMachine(string name)
            : base(name)
        {
        }

        public override bool Visit(Flu condition)
        {
            return false;
        }

        public override bool Visit(Cancer condition)
        {
            switch (condition.Topology)
            {
                case Topology.Head:
                case Topology.Neck:
                    return true;
                default:
                    return false;
            }
        }
    }
}