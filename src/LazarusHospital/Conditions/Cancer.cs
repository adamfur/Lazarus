using LazarusHospital.Interfaces;

namespace LazarusHospital.Conditions
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

        public override string ToString()
        {
            return $"Cancer: {Topology}";
        }        
    }
}