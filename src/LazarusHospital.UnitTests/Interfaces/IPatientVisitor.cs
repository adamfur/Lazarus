using LazarusHospital.UnitTests.Conditions;

namespace LazarusHospital.UnitTests.Interfaces
{
    public interface IPatientVisitor
    {
        bool Visit(Flu flu);
        bool Visit(Cancer flu);
    }
}