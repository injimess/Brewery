using System;
using System.Collections.Generic;
using System.Linq;
using BreweryBusiness.DTOs;
using BreweryBusiness.Services.Interfaces;
using BreweryData.Entities;
using BreweryBusiness.Repositories.Implementations;
using BreweryBusiness.Repositories.Interfaces;
using BreweryData;

namespace BreweryBusiness.Services.Implementations
{
    public class BeerService : IBeerService
    {

        private readonly IBeerRepository _beerRepository;
        private readonly IBreweryRepository _breweryRepository;
        private readonly IWholesalerRepository _wholesalerRepository;
        public BeerService(IBeerRepository beerRepository,IBreweryRepository breweryRepository, IWholesalerRepository wholesalerRepository)
        {
            _beerRepository = beerRepository;
            _breweryRepository = breweryRepository;
            _wholesalerRepository = wholesalerRepository;
        }
        public Beer AddBeer(Beer beer)
        {
            return _beerRepository.AddBeer(beer);
        }

        public List<BeerDetailsDTO> GetAllBeers()
        {
            List<BeerDetailsDTO> AllBeers = new List<BeerDetailsDTO>();
            var beers = _beerRepository.GetAllBeers();
            foreach (var b in beers)
            {
                BeerDetailsDTO beerDetails = new BeerDetailsDTO();
                beerDetails.Beer = b.Name;

                var brewery = _breweryRepository.GetBrewery(b.BreweryId);                    
                beerDetails.Brewery = brewery.Name;

                var wholesalersName = _wholesalerRepository.GetWholeSalerNameByBeerId(b.Id);
                beerDetails.Wholesalers = wholesalersName;

                AllBeers.Add(beerDetails);
                
            }
            return AllBeers;
        }

        public Beer GetBeer(Guid id)
        {
            return _beerRepository.GetBeer(id);
        }

        public void DeleteBeer(Guid id)
        {
            var beer = _beerRepository.GetBeer(id);
            _beerRepository.DeleteBeer(beer);
        }
    }
}
