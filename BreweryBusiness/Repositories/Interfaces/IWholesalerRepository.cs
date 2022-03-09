using BreweryBusiness.Base;
using BreweryData.Entities;
using BreweryBusiness.DTOs;
using BreweryData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryBusiness.Repositories.Interfaces
{
    public interface IWholesalerRepository : IRepository<Wholesaler>
    {
        public void Update(Guid idBeer, Guid idWholesaler, long newQuantity);
        public SummaryDTO RequestQuote(Guid idWholesaler, Dictionary<Guid, int> QuoteDetails);
        public WholesalerBeer Add(Guid idBeer, Guid idWholesaler , long Quantity);
        public List<String> GetWholeSalerNameByBeerId(Guid id);
        public void Delete(Guid idBeer, Guid idWholesaler);

    }
}
