using System;
using LazarusHospital.UnitTests.Employee.Roles;
using LazarusHospital.UnitTests.Interfaces;

namespace LazarusHospital.UnitTests.Conditions
{
    public abstract class Condition : ICondition
    {
        public abstract void Accept(IConditionVisistor visitor);

        internal bool Accept(IPatientVisitor visitor)
        {
            throw new NotImplementedException();
        }

        internal bool Accept(GeneralPractitioner visitor)
        {
            throw new NotImplementedException();
        }
    }
}