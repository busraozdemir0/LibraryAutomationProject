using LibraryAutomation.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Repository
{
    public class GenericRepository<TContext, TEntity> : IGenericRepository<TContext, TEntity>
           where TContext : DbContext, new()
           where TEntity : class, new()
    {
        public void Delete(TContext context, Expression<Func<TEntity, bool>> filter)
        {
            var model = context.Set<TEntity>().FirstOrDefault(filter);
            context.Set<TEntity>().Remove(model);
        }

        public List<TEntity> GetAll(TContext context, Expression<Func<TEntity, bool>> filter = null, string table = null)
        {
            // Tablo bilgisi geldiyse gelen tabloyu include etmek icin yapiyi duzenledik

            return filter == null ? table == null
                ? context.Set<TEntity>().ToList() // hem filtreleme hem de include edilecek tablo adi bos ise calisir
                : context.Set<TEntity>().Include(table).ToList() // eger filtreleme bos fakat table ifadesi bos degilse

                : table == null // eger filter dolu table bos ise
                ? context.Set<TEntity>().Where(filter).ToList()
                : context.Set<TEntity>().Include(table).Where(filter).ToList(); // hem filter hem de table ifadesi dolu gelirse
        }

        public TEntity GetByFilter(TContext context, Expression<Func<TEntity, bool>> filter, string table = null)
        {
            // table degeri bos gelmedigi surece include et
            return table == null
                ? context.Set<TEntity>().FirstOrDefault(filter)
                : context.Set<TEntity>().Include(table).FirstOrDefault(filter);
        }

        public TEntity GetById(TContext context, int? id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void InsertorUpdate(TContext context, TEntity entity)
        {
            context.Set<TEntity>().AddOrUpdate(entity);
        }

        public void Save(TContext context)
        {
            context.SaveChanges();
        }
    }
}
