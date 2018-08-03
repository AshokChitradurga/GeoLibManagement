namespace GeoLib.Core
{
    using GeoLib.Common.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class DataRepositoryBase<T, U> : IDataRepository<T>
        where T : class, IIdentityKey, new()
        where U : DbContext, new()
    {
        protected abstract DbSet<T> DbSet(U context);
        protected abstract Expression<Func<T, bool>> Predicate(int id);

        public virtual T Insert(T entity)
        {
            using (U context = new U())
            {
                T temp = DbSet(context).Add(entity);
                context.SaveChanges();
                return temp;
            }
        }
        public virtual int Remove(int id)
        {
            int isRemoved = default(int);
            using (U context = new U())
            {
                T current = SelectRecordByKey(id);
                context.Entry<T>(current).State = EntityState.Deleted;
                context.SaveChanges();
                isRemoved = 1;
            }

            return isRemoved;
        }
        public virtual int Remove(T entity)
        {
            int isRemoved = default(int);
            using (U context = new U())
            {
                context.Entry<T>(entity).State = EntityState.Deleted;
                context.SaveChanges();
                isRemoved = 1;
            }

            return isRemoved;
        }
        public virtual IEnumerable<T> SelectAllRecords()
        {
            using (U context = new U())
            {
                return DbSet(context).ToList();
            }
        }
        public virtual T SelectRecordByKey(int id)
        {
            using (U context = new U())
            {
                return DbSet(context).Where(Predicate(id)).FirstOrDefault();
            }
        }
        public virtual T Update(T newEntity)
        {
            using (U context = new U())
            {
                T existingEntity = DbSet(context).Where(Predicate(newEntity.EntityId)).FirstOrDefault();
                SimpleMapper.Instance().PropertyMapper(existingEntity, newEntity);
                context.SaveChanges();
                return existingEntity;
            }
        }
    }
}
