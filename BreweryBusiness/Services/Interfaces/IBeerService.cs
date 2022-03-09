using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryBusiness.DTOs;
using BreweryData.Entities;

namespace BreweryBusiness.Services.Interfaces
{
    public interface IBeerService
    {
        public Beer GetBeer(Guid id);
        public List<BeerDetailsDTO> GetAllBeers();
        public Beer AddBeer(Beer beer);
        public void DeleteBeer(Guid id);


    }
}
