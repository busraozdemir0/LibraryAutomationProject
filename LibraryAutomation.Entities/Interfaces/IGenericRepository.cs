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
        // params string[] table => ifadesi ile birden fazla tablo include edecegimiz icin (Ornegin; EmanetKitaplar tablosuna Kitaplar ve Uyeler tablolarini include edecegiz)
        List<TEntity> GetAll(TContext context, Expression<Func<TEntity, bool>> filter = null, params string[] table); // Eger filtre null gelirse tum listeyi getir. Filtre null degilse de filtreleyerek getir.
        TEntity GetByFilter(TContext context, Expression<Func<TEntity, bool>> filter, params string[] table); // Tek kayit getirir.
        TEntity GetById(TContext context, int? id);
        void InsertorUpdate(TContext context, TEntity entity);
        void Delete(TContext context, Expression<Func<TEntity, bool>> filter);
        void Save(TContext context);
    }
}
