using System.Linq;
using LazarusHospital.Conditions;
using LazarusHospital.Employee.Roles;
using LazarusHospital.Interfaces;

namespace LazarusHospital.Employee
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