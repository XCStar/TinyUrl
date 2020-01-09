using System.Data.Common;
using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TinyUrl.IDal;
using TinyUrl.Model;

namespace TinyUrl.Dal
{
    public class BaseDal<T>:IBaseDal<T> where T:Entity
    {
        private EFContext _dbContext;
        private DbSet<T> _db;
        public BaseDal(EFContext dbContext)
        {
            this._dbContext=dbContext;
            this._db=_dbContext.Set<T>();
        }

        public bool Add(T item)
        {
            if(item==null)
            {
                throw new ArgumentNullException("this add method requeire argument is not null");
            }
            this._db.Add(item);
           return this._dbContext.SaveChanges()==1;
        }

        public bool DelByID(int ID)
        {
           var item=FindByID(ID);
            _db.Remove(item);
            return _dbContext.SaveChanges()==1;
        }

        public T FindByID(int ID)
        {
            var item=_db.Where(x=>x.ID==ID).FirstOrDefault();
            if(item==null||item.ID==0)
            {
                return default(T);
            }
            return item;
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> expression)
        {
            return _db.Where(expression);
        }

        public bool UpdateByID(T item)
        {
           var model= _db.Update(item);
           return true;
        }
    }

}