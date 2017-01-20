using LazarusHospital.UnitTests.Employee.Roles;
using LazarusHospital.UnitTests.Interfaces;
using LazarusHospital.UnitTests.TreatmentRooms.Machines;

namespace LazarusHospital.UnitTests.Conditions
{
    public class Flu : Condition
    {
        //public override bool Visit(AdvancedTreatmentMachine treatmentMachine)
        //{
        //    return false;
        //}

        //public override bool Visit(NullTreatmentMachine treatmentMachine)
        //{
        //    return true;
        //}

        //public override bool Visit(SimpleTreatmentMachine treatmentMachine)
        //{
        //    return false;
        //}

        //public override bool Visit(GeneralPractitioner doctor)
        //{
        //    return true;
        //}

        //public override bool Visit(Oncologist doctor)
        //{
        //    return false;
        //}

        //public override bool Accept(IPatientVisitor visitor)
        //{
        //    return visitor.Visit(this);
        //}

        public override void Accept(IConditionVisistor visitor)
        {
            visitor.Visit(this);
        }
    }
}