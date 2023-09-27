using SocialNetwork.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.DataAccess
{
    public interface IRepositoryBase<T> where T : class, IEntity //yalniz IEntity den inherit almislar 
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(Expression<Func<T, bool>> predicate);
        List<T> GetAll(Expression<Func<T, bool>> predicate = null);

    }
}
