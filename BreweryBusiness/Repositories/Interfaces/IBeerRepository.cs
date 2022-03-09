using BreweryBusiness.Base;
using BreweryBusiness.DTOs;
using BreweryData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryBusiness.Repositories.Interfaces
{
    public interface IBeerRepository : IRepository<Beer>
    {
        public Beer GetBeer(Guid id);
        public List<Beer> GetAllBeers();
        public Beer AddBeer(Beer beer);
        public void DeleteBeer(Beer beer);

    }
}
