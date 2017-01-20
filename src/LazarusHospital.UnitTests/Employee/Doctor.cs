using System.Linq;
using LazarusHospital.UnitTests.Conditions;
using LazarusHospital.UnitTests.Employee.Roles;
using LazarusHospital.UnitTests.Interfaces;

namespace LazarusHospital.UnitTests.Employee
{
    public class Doctor : Resource, ICanTreat, IConditionVisistor
    {
        private Role[] Roles { get; set; }

        public Doctor(string name, Role[] roles)
            : base(name)
        {
            Roles = roles;
        }

        public bool CanTreat(Patient patient)
        {
            return Roles.Any(r => r.CanTreat(patient));
        }

        public void Visit(Flu condition)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(Cancer condition)
        {
            throw new System.NotImplementedException();
        }
    }
}