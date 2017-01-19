using LazarusHospital.UnitTests.Interfaces;

namespace LazarusHospital.UnitTests.Employee.Roles
{
    public abstract class Role : ICanTreat
    {
        public abstract bool CanTreat(Patient patient);
    }
}