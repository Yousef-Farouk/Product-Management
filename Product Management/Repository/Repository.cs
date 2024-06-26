﻿
using Microsoft.EntityFrameworkCore;
using Product_Management.Models;

namespace Product_Management.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
       public ProductManagementContext db;

        public Repository(ProductManagementContext _db) 
        {
            db = _db;
            
        }
        
        public IQueryable<T> GetAll()
        {
            return db.Set<T>().AsQueryable();
        }


        public T GetByID(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            db.Set<T>().Add(entity);

        }

        public void Update(T entity)
        {
            db.Set<T>().Update(entity);
        }

        public void Delete(int id)
        {
            T obj = db.Set<T>().Find(id);

            db.Set<T>().Remove(obj);
        }

        public void Delete(T obj)
        {
            db.Set<T>().Remove(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
