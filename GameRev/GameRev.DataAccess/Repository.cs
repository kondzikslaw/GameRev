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

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return _entities.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            _entities.Add(entity);
            _gameRevStorageContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            _entities.Update(entity);
            _gameRevStorageContext.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = _entities.SingleOrDefault(x => x.Id == id);
            _entities.Remove(entity);
            _gameRevStorageContext.SaveChanges();
        }        
    }
}
