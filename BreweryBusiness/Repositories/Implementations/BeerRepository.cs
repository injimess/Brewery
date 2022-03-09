using BreweryBusiness.Base;
using BreweryData;
using BreweryData.Entities;
using BreweryBusiness.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryBusiness.DTOs;

namespace BreweryBusiness.Repositories.Implementations
{
    public class BeerRepository : Repository<Beer>, IBeerRepository
    {
        
        public BeerRepository(BreweryDbContext breweryDb) : base(breweryDb)
        { 
            
        }

        public BreweryDbContext Context { get { return (BreweryDbContext)context; } }

        public Beer GetBeer(Guid id)
        {
            var beer = context.Set<Beer>().FirstOrDefault(b => b.Id == id);
            return beer;
        }

        public List<Beer> GetAllBeers()
        {
          
            var beers = this.GetAll().ToList();
            if ( beers == null)
            {
                return null;
            }

            return beers;
        }

        public Beer AddBeer(Beer beer)
        {
            beer.Id = new Guid();
            this.Add(beer);
            return beer;
        }

        public void DeleteBeer(Beer beer)
        {
                this.Remove(beer);
        }
    }
}
