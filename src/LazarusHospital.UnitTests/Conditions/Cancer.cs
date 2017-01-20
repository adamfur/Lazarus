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

        public override bool CanBeTreatedBy(IConditionVisistor visitor)
        {
            return visitor.CanTreatCondition(this);
        }
    }
}