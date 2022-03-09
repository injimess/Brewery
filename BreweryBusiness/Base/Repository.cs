using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryData;

namespace BreweryBusiness.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //Get dbcontext
        protected readonly BreweryDbContext context;

        public Repository(BreweryDbContext context) 
        {
            this.context = context;
        }

        public virtual void Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public T Get(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }


    }
}
