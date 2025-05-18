using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;

namespace StoreOfBuild.Data
{
    public class RepositoryProduct : Repository<Product>
    {
        private readonly ApplicationDbContext _context;
        public RepositoryProduct(ApplicationDbContext context) : base(context)
        {
    
        }
        
        public Product GetByID(int id)
        {
            return _context.Set<Product>().Include(x => x.Category).SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<Product> GetAll()
         {
            return _context.Set<Product>().AsEnumerable();
         }

        public void Save(Product entity)
        {
            _context.Set<Product>().Add(entity);
        }
    }
}