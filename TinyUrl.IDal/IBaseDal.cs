using System.Linq.Expressions;
using System.Linq;
using System;
using TinyUrl.Model;

namespace TinyUrl.IDal
{
    public interface IBaseDal<T> where T:Entity
    {
        bool Add(T item);
        T FindByID(int ID);
        bool DelByID(int ID);
        bool UpdateByID(T item);

        IQueryable<T> Query(Expression<Func<T,bool>> expression) ;

    }
    
}