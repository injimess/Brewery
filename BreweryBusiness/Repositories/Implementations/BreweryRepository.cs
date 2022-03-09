using BreweryBusiness.Base;
using BreweryBusiness.Repositories.Interfaces;
using BreweryData;
using BreweryData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryBusiness.Repositories.Implementations
{
   public  class BreweryRepository : Repository<Brewery>, IBreweryRepository
    {
        public BreweryRepository(BreweryDbContext breweryDb) : base(breweryDb)
        {

        }

        public BreweryDbContext Context { get { return (BreweryDbContext)context; } }
        public Brewery GetBrewery(Guid id)
        {
            var brewery = context.Set<Brewery>().FirstOrDefault(b => b.Id == id);
            return brewery;
        }
    }
}
