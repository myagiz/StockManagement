using Core.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository.Concrete
{
    public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using TContext context = new TContext();
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity GetById(int id)
        {
            using var context = new TContext();
            return context.Set<TEntity>().Find(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using TContext context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(filter);
        }

        public void Add(TEntity entity)
        {
            using TContext context = new TContext();
            var isActiveProperty = entity.GetType().GetProperty("IsActive");
            if (isActiveProperty != null && isActiveProperty.PropertyType == typeof(bool))
            {
                isActiveProperty.SetValue(entity, true);
            }
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            using TContext context = new TContext();
            var isActiveProperty = entity.GetType().GetProperty("IsActive");
            isActiveProperty.SetValue(entity, true);
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using TContext context = new TContext();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void ChangeStatus(TEntity entity)
        {
            using TContext context = new TContext();
            var isActiveProperty = entity.GetType().GetProperty("IsActive");
            if (isActiveProperty != null && isActiveProperty.PropertyType == typeof(bool))
            {
                bool currentValue = (bool)isActiveProperty.GetValue(entity);
                isActiveProperty.SetValue(entity, !currentValue);
            }
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
