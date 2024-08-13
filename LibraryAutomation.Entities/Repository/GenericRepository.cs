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

        public List<TEntity> GetAll(TContext context, Expression<Func<TEntity, bool>> filter = null, params string[] table)
        {
            // Tablo bilgisi geldiyse gelen tabloyu include etmek icin yapiyi duzenledik

            //return filter == null ? table == null
            //    ? context.Set<TEntity>().ToList() // hem filtreleme hem de include edilecek tablo adi bos ise calisir
            //    : context.Set<TEntity>().Include(table).ToList() // eger filtreleme bos fakat table ifadesi bos degilse

            //    : table == null // eger filter dolu table bos ise
            //    ? context.Set<TEntity>().Where(filter).ToList()
            //    : context.Set<TEntity>().Include(table).Where(filter).ToList(); // hem filter hem de table ifadesi dolu gelirse

            // Ornegin EmanetKitaplar tablosuna birden fazla tabloyu include edecegimiz icin bu sekilde params ile kac tablo gelirse dongu yardimiyla donerek tablolari dahil ediyoruz.
            IQueryable<TEntity> query = context.Set<TEntity>();
            foreach (var item in table) // Bir veya birden fazla tablo dahil edilecekse (Hic tablo dahil edilmezse dongu zaten calismayacaktir.)
            {
                query = query.Where(filter).Include(item);
            }
            return query.ToList();
        }

        public TEntity GetByFilter(TContext context, Expression<Func<TEntity, bool>> filter, params string[] table)
        {
            // table degeri bos gelmedigi surece include et
            //return table == null
            //    ? context.Set<TEntity>().FirstOrDefault(filter)
            //    : context.Set<TEntity>().Include(table).FirstOrDefault(filter);
        
            IQueryable<TEntity> query= context.Set<TEntity>();
            foreach(var item in table) // Bir veya birden fazla tablo dahil edilecekse (Hic tablo dahil edilmezse dongu zaten calismayacaktir.)
            {
                query = query.Include(item);
            }
            return query.FirstOrDefault(filter);
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
