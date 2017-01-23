using System;

namespace LazarusHospital.Conditions
{
    public static class ConditionFactory
    {
        public static Condition Create(string conditionText)
        {
            switch (conditionText.ToLower())
            {
                case "flu":
                    return new Flu();
                case "cancerhead":
                    return new Cancer(Topology.Head);
                case "cancerneck":
                    return new Cancer(Topology.Neck);
                case "cancerbreast":
                    return new Cancer(Topology.Breast);
                default:
                    throw new Exception($"Unknown Condition: {conditionText}");
            }
        }
    }
}