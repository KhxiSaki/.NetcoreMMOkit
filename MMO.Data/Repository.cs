using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MMO.Interfaces;
using System.Linq.Expressions;
using MMO.Data;
using System.Dynamic;

namespace MMO.Services
{
    public class Repository<TEntity> where TEntity : class
    {
        internal DatabaseContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(DatabaseContext context = null)
        {
            if (this.context == null)
            {
                context = new DatabaseContext();
            }
            else
            {
                this.context = context;
            }

            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        internal virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }






    //public class UnitOfWork : IDisposable
    //{
    //    private DatabaseContext context = new DatabaseContext();
    //    private Repository<Department> departmentRepository;
    //    private Repository<Course> courseRepository;

    //    public Repository<Department> DepartmentRepository
    //    {
    //        get
    //        {

    //            if (this.departmentRepository == null)
    //            {
    //                this.departmentRepository = new Repository<Department><Department>(context);
    //            }
    //            return departmentRepository;
    //        }
    //    }

    //    public Repository<Course> CourseRepository
    //    {
    //        get
    //        {

    //            if (this.courseRepository == null)
    //            {
    //                this.courseRepository = new Repository<Course><Course>(context);
    //            }
    //            return courseRepository;
    //        }
    //    }

    //    public void Save()
    //    {
    //        context.SaveChanges();
    //    }

    //    private bool disposed = false;

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!this.disposed)
    //        {
    //            if (disposing)
    //            {
    //                context.Dispose();
    //            }
    //        }
    //        this.disposed = true;
    //    }

    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }
    //}
}

