namespace OnionArchitecture.Repository.Tests
{
    public class DummyRepository : GenericRepository<Dummy>
    {
        public DummyRepository(Context context) : base(context)
        {
        }
    }
}
