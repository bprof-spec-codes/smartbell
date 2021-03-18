using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T> where T:class
    {
        void Insert(T entity);

        T GetOne(string id);

        IQueryable<T> GetAll();

        void Delete(T entity);

        void SaveChanges();


    }
    public abstract class Repository<T> : IRepository<T> where T:class
    {
        private SbDbContext context = new SbDbContext();
        public Repository(SbDbContext context)
        {
            this.context = context;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public abstract T GetOne(string id);
        

        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
