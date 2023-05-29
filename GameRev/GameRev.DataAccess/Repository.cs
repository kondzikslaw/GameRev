using GameRev.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameRev.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly GameRevStorageContext _gameRevStorageContext;
        private DbSet<T> _entities;

        public Repository(GameRevStorageContext gameRevStorageContext)
        {
            _gameRevStorageContext = gameRevStorageContext;
            _entities = gameRevStorageContext.Set<T>();
        }

        public Task<List<T>> GetAll()
        {
            return _entities.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return _entities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            _entities.Add(entity);
            return _gameRevStorageContext.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            _entities.Update(entity);
            return _gameRevStorageContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = _entities.SingleOrDefault(x => x.Id == id);
            _entities.Remove(entity);
            await _gameRevStorageContext.SaveChangesAsync();
        }        
    }
}
