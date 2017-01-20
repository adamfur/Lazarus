namespace LazarusHospital.UnitTests.Interfaces
{
    public interface ICondition
    {
        void Accept(IConditionVisistor visitor);
    }
}