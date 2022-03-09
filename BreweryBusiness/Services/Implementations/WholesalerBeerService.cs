using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryBusiness.Services.Interfaces;
using BreweryData.Entities;
using BreweryBusiness.Repositories.Interfaces;
using BreweryBusiness.DTOs;

namespace BreweryBusiness.Services.Implementations
{
    public class WholesalerBeerService : IWholesalerBeerService
    {
        private readonly IWholesalerRepository _wholesalerRepository;
        public WholesalerBeerService(IWholesalerRepository beerRepository)
        {
            _wholesalerRepository = beerRepository;
        }
        public WholesalerBeer Add(Guid idBeer, Guid idWholesaler, long Quantity)
        {
            return _wholesalerRepository.Add(idBeer, idWholesaler, Quantity);
        }

        public SummaryDTO RequestQuote(Guid idWholesaler, Dictionary<Guid, int> QuoteDetails)
        {
            return _wholesalerRepository.RequestQuote(idWholesaler,QuoteDetails);
        }

        public void Update(Guid idBeer, Guid idWholesaler, long newQuantity)
        {
            _wholesalerRepository.Update(idBeer, idWholesaler,newQuantity);
        }

        public void Delete(Guid idBeer, Guid idWholesaler)
        {
            _wholesalerRepository.Delete(idBeer, idWholesaler);
        }
    }
}
