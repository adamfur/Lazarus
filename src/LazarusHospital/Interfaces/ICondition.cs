namespace LazarusHospital.UnitTests.Interfaces
{
    public interface ICondition
    {
        bool CanBeTreatedBy(IConditionVisistor visitor);
    }
}