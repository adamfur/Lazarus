namespace LazarusHospital.Interfaces
{
    public interface ICondition
    {
        bool CanBeTreatedBy(IConditionVisistor visitor);
    }
}