﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechCareerProject_.Context;
using TechCareerProject_.DesignPattern.SingletonPattern;
using TechCareerProject_.Models;

namespace TechCareerProject_.Repositories
{
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        MyContext _db;
        public BaseRepository()
        {
            _db = DBTool.DBInstance;
        }

        void Save()
        {
            _db.SaveChanges();
        }
        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
        }

        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange(list);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            item.DeletedDate = DateTime.Now;
            Save();
        }

        public void DeleteRange(List<T> list)
        {
            foreach (T item in list) Delete(item);
        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            Save();
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return Where(x => x.DeletedDate == null);
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetFirstDatas(int number)
        {
            return _db.Set<T>().OrderBy(x => x.CreatedDate).Take(number).ToList();
        }

        public List<T> GetLastDatas(int number)
        {
            return _db.Set<T>().OrderByDescending(x => x.CreatedDate).Take(number).ToList();
        }

        public List<T> GetPassives()
        {
            return Where(x => x.DeletedDate != null);
        }

        public List<T> GetModifieds()
        {
            return Where(x => x.ModifiedDate != null);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp).ToList();
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public void Update(T item)
        {
            item.ModifiedDate = DateTime.Now;
            T toBeUpdated = Find(item.ID);
            _db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            Save();
        }

        public void UpdateRange(List<T> list)
        {
            foreach (T item in list) Update(item);
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }
    }
}
