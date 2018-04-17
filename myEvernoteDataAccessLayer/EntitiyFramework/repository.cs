using myEvernoteCommon;
using myEvernoteDataAccessLayer.Abstract;
using MyEvernoteEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace myEvernoteDataAccessLayer.EntityFramework
{
    public class repository<T> : repositoryBase, iRepo<T> where T : class
    {
        private databaseContext db;
        private DbSet<T> _objectSet;

        public repository()
        {
            db = repositoryBase.context;
            _objectSet = db.Set<T>();
        }

        public List<T> list()
        {
            return db.Set<T>().ToList();

        }

        public List<T> list(Expression <Func<T,bool>> where)
        {
            return _objectSet.Where(where).ToList();
            
        }

        public int insert(T obj)
        {
            _objectSet.Add(obj);
            if (obj is myEntitiesBase)
            {
                myEntitiesBase o = obj as myEntitiesBase;
                DateTime now = DateTime.Now;
                o.createdOn = now;
                o.modifiedOn = now;
                //o.modifiedUserName = app.common.GetUserName();
            }
            return save();
        }

        public int update(T obj)

        {
            if (obj is myEntitiesBase)
            {
                myEntitiesBase o = obj as myEntitiesBase;
                DateTime now = DateTime.Now;
                o.createdOn = now;
                o.modifiedOn = now;
                o.modifiedUserName = app.common.GetUserName(); ;
            }
            return save();
        }

        public int delete(T obj)
        {
            _objectSet.Remove(obj);
            return save();

        }

        public int save()
        {
            return db.SaveChanges();
        }

        public T find(Expression<Func<T, bool>> where) 
        {
            return _objectSet.FirstOrDefault(where);
        }
    }
}
