namespace LazarusHospital.UnitTests
{
    public abstract class Resource
    {
        public string Name { get; private set; }

        public Resource(string name)
        {
            Name = name;
        }
    }
}