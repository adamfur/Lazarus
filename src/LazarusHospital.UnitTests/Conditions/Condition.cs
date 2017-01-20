using LazarusHospital.UnitTests.Employee.Roles;
using LazarusHospital.UnitTests.TreatmentRooms.Machines;

namespace LazarusHospital.UnitTests.Conditions
{
    public interface ICondition
    {
        void Accept(IConditionVisistor visitor);
    }

    public interface IConditionVisistor
    {
        void Visit(Flu condition);
        void Visit(Cancer condition);
    }

    public abstract class Condition : ICondition
    {
        public abstract void Accept(IConditionVisistor visitor);        
    }
}