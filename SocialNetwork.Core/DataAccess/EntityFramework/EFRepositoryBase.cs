using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SocialNetwork.Core.DataAccess.EntityFramework
{
    public class EFRepositoryBase<T, TContext> : IRepositoryBase<T> where T : class where TContext : DbContext, new()
    {
        public void Add(T entity)
        {
            using TContext context = new();//bazani getir
            var addEntity=context.Entry(entity); //deyisen getir ve bazaya qos
            addEntity.State = EntityState.Added;
            context.SaveChanges();


        }

        public void Delete(T entity)
        {
            using TContext context = new();
            var deleteEntity=context.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            using TContext context=new();
            var updateEntity=context.Entry(entity);
            updateEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
        public T Get(Expression<Func<T, bool>> predicate)
        {
           using TContext context=new();
            return context.Set<T>().FirstOrDefault(predicate);// belirli bir varlık türünün tabloya karşılık geldiği yerdir

        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            using TContext  context = new();
            return predicate==null
                ? context.Set<T>().ToList() : context.Set<T>().Where(predicate).ToList();
        }


    }
}
