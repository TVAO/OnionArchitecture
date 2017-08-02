using OnionArchitecture.Repository.Interfaces;

namespace OnionArchitecture.Repository.Tests
{
    public class Dummy : IEntity
    {
        public int Id { get; set; }
        public int DummyVariable { get; set; }
    }
}
