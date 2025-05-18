using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Domain;

namespace StoreOfBuild.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public TEntity GetByID(int id, string itens = null)
        {
            if (!string.IsNullOrEmpty(itens))
                return _context.Set<TEntity>().Include(itens).SingleOrDefault(e => e.Id == id);
            else
                return _context.Set<TEntity>().SingleOrDefault(e => e.Id == id);
        }

        public void DeleteByID(int id)
        {
            _context.Set<TEntity>().Where(x => x.Id == id).ExecuteDelete();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public void Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
    }
}