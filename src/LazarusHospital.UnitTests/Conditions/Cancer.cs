using LazarusHospital.UnitTests.Employee.Roles;
using LazarusHospital.UnitTests.Interfaces;
using LazarusHospital.UnitTests.TreatmentRooms.Machines;

namespace LazarusHospital.UnitTests.Conditions
{
    public class Cancer : Condition
    {
        public Topology Topology { get; private set; }
        public Cancer(Topology topology)
        {
            Topology = topology;
        }

        //public override bool Visit(AdvancedTreatmentMachine treatmentMachine)
        //{
        //    switch (Topology)
        //    {
        //        case Topology.Head:
        //        case Topology.Neck:
        //            return true;
        //        default:
        //            return false;
        //    }
        //}

        //public override bool Visit(SimpleTreatmentMachine treatmentMachine)
        //{
        //    return Topology == Topology.Breast;
        //}

        public override bool Accept(IConditionVisistor visitor)
        {
            return visitor.Visit(this);
        }
    }
}