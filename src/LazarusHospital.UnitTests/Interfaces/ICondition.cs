namespace LazarusHospital.UnitTests.Interfaces
{
    public interface ICondition
    {
        bool Accept(IConditionVisistor visitor);
    }
}