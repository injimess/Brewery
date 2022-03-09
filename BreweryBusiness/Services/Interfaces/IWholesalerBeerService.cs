using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryData.Entities;
using BreweryBusiness.DTOs;

namespace BreweryBusiness.Services.Interfaces
{
    public interface IWholesalerBeerService
    {
        public WholesalerBeer Add(Guid idBeer, Guid idWholesaler, long Quantity);
        public void Update(Guid idBeer, Guid idWholesaler, long newQuantity);
        public SummaryDTO RequestQuote(Guid idWholesaler, Dictionary<Guid, int> QuoteDetails);
        public void Delete(Guid idBeer, Guid idWholesaler);
    }
}
