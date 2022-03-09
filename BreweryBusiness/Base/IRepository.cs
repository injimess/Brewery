using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryBusiness.Base
{
    public interface IRepository<T> where T : class
    {
        //CRUD Methods

        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        T Get(Guid id);
        IEnumerable<T> GetAll();
    }
}
