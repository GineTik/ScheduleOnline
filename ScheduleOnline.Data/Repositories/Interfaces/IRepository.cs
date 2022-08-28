namespace ScheduleOnline.Data.Repositories.Interfaces
{
    public interface IRepository<TEntity>
    {
        void AddItem(TEntity item);
        void DeleteItem(TEntity item);
        void UpdateItem(TEntity item);
        TEntity? GetItem(Guid id);
        IQueryable<TEntity> GetAll();
    }
}
