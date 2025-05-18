using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreOfBuild.Domain
{
    public interface IRepository<TEntity>
    {
        TEntity GetByID(int id, string itens = null);

        IQueryable<TEntity> GetAll();

        void Save(TEntity entity);

        void DeleteByID(int id);
    }
}