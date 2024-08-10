using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Interfaces
{
    public interface IGenericRepository<TContext, TEntity>
        where TContext : DbContext, new()
        where TEntity : class, new()
    {
        List<TEntity> GetAll(TContext context, Expression<Func<TEntity, bool>> filter = null, string table = null); // Eger filtre null gelirse tum listeyi getir. Filtre null degilse de filtreleyerek getir.
        TEntity GetByFilter(TContext context, Expression<Func<TEntity, bool>> filter, string table = null); // Tek kayit getirir.
        TEntity GetById(TContext context, int? id);
        void InsertorUpdate(TContext context, TEntity entity);
        void Delete(TContext context, Expression<Func<TEntity, bool>> filter);
        void Save(TContext context);
    }
}
