namespace LazarusHospital.UnitTests
{
    public abstract class Resource
    {
        public string Name { get; private set; }

        protected Resource(string name)
        {
            Name = name;
        }
    }
}