﻿using LibraryAutomation.Entities.Interfaces;
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

        public List<TEntity> GetAll(TContext context, Expression<Func<TEntity, bool>> filter = null)
        {
            // Eger filter null ise tum listeyi, filter null degilse de filtreye gore listelesin.
            return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity GetByFilter(TContext context, Expression<Func<TEntity, bool>> filter)
        {
            return context.Set<TEntity>().FirstOrDefault(filter);
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
