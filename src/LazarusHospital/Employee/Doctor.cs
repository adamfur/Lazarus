using System.Linq;
using LazarusHospital.UnitTests.Conditions;
using LazarusHospital.UnitTests.Employee.Roles;
using LazarusHospital.UnitTests.Interfaces;

namespace LazarusHospital.UnitTests.Employee
{
    public class Doctor : Resource, IConditionVisistor
    {
        private Role[] Roles { get; set; }

        public Doctor(string name, Role[] roles)
            : base(name)
        {
            Roles = roles;
        }

        public bool CanTreatCondition(Flu condition)
        {
            return Roles.Any(r => r.CanTreatCondition(condition));
        }

        public bool CanTreatCondition(Cancer condition)
        {
            return Roles.Any(r => r.CanTreatCondition(condition));
        }
    }
}