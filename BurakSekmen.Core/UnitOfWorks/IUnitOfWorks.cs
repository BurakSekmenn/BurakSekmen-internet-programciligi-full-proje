namespace BurakSekmen.Core.UnitOfWorks
{
    public interface IUnitOfWorks
    {
        Task CommitAsync();
        void Commit();
    }
}
