using BreweryBusiness.Base;
using BreweryData;
using BreweryData.Entities;
using BreweryBusiness.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using BreweryBusiness.DTOs;

namespace BreweryBusiness.Repositories.Implementations
{
    public class WholesalerRepository : Repository<Wholesaler>, IWholesalerRepository
    {
        public WholesalerRepository(BreweryDbContext breweryDb) : base(breweryDb)
        {

        }

        public BreweryDbContext Context { get { return (BreweryDbContext)context; } }

        public WholesalerBeer Add(Guid idBeer, Guid idWholesaler, long Quantity)
        {
            WholesalerBeer wholesalerBeer = new WholesalerBeer();
            wholesalerBeer.BeerId = idBeer;
            wholesalerBeer.WholesalerId = idWholesaler;
            wholesalerBeer.Quantity = Quantity; 
            wholesalerBeer.Id = new Guid();
            context.WholesalerBeer.Add(wholesalerBeer);
            context.SaveChanges();
            return wholesalerBeer;
        }

        public void Update(Guid idBeer, Guid idWholesaler, long newQuantity)
        {

            WholesalerBeer _wholesalerBeer = context.WholesalerBeer.FirstOrDefault(wb => wb.BeerId == idBeer && wb.WholesalerId == idWholesaler);
            _wholesalerBeer.Quantity = newQuantity;
            context.SaveChanges();
        }

        public Boolean CheckDuplicateOrder(List<QuoteDetailsDTO> order)
        {
            var duplicate = order.GroupBy(o => o.BeerId).Any(c => c.Count() > 1);
            if (duplicate)
                return true;

            return false;
        }

        public SummaryDTO RequestQuote(Guid idWholeSaler,Dictionary<Guid, int> _quoteDetails)
        {
            List<QuoteDetailsDTO> quoteDetails = new List<QuoteDetailsDTO>();
            QuoteDetailsDTO quoteDetail = new QuoteDetailsDTO();
            foreach (var qd in _quoteDetails)
            {
                quoteDetail.BeerId = qd.Key;
                quoteDetail.Quantity = qd.Value;
                quoteDetails.Add(quoteDetail);
            }
            QuoteRequestDTO request = new QuoteRequestDTO();
            request.WholesalerId = idWholeSaler;
            request.QuoteDetails = quoteDetails;

            SummaryDTO summary = new SummaryDTO();

            decimal Price = 0;
            decimal TotalPrice = 0;
            decimal Discount = 0;
            int TotalQuantity = 0;
            List<QuoteDetailsDTO> AvailableBeers = new List<QuoteDetailsDTO>();
            List<QuoteDetailsDTO> NotExistingBeers = new List<QuoteDetailsDTO>();
            List<QuoteDetailsDTO> NotInStockBeers = new List<QuoteDetailsDTO>();

            if (request.QuoteDetails.Count <= 0)
                return null;

            foreach (var qd in request.QuoteDetails)
            {
                WholesalerBeer wholesalerBeer = context.WholesalerBeer.FirstOrDefault(wb => wb.BeerId == qd.BeerId && wb.WholesalerId == request.WholesalerId);
                if (wholesalerBeer != null)
                {
                    //Check if the quantity ordered is in stock
                    if (qd.Quantity > wholesalerBeer.Quantity)
                    {
                        NotInStockBeers.Add(qd);
                        continue;
                    }

                    //Get the beer price
                    Beer beer = context.Beer.FirstOrDefault(b => b.Id == qd.BeerId);
                    Price = Price + (beer.Price * qd.Quantity);
                    TotalQuantity = TotalQuantity + qd.Quantity;

                    AvailableBeers.Add(qd);
                }
                else
                {
                    //if beer does not exist
                    NotExistingBeers.Add(qd);
                    continue;
                }
            }

            if (TotalQuantity > 10)
            {
                Discount = (Price * 10) / 100;

                if (TotalQuantity > 20)
                    Discount = (Price * 20) / 100;
            }

            TotalPrice = Price - Discount;

            summary = new SummaryDTO()
            {
                NotInStockBeers = NotInStockBeers,
                AvailableBeers = AvailableBeers,
                NotExistingBeers = NotExistingBeers,
                Discount = Discount,
                Price = Price,
                TotalPrice = TotalPrice
            };

            return summary;

        }

        public List<String> GetWholeSalerNameByBeerId(Guid id)
        {
            List<String> WholeSalersName = new List<String>();
            var wholesalers = Context.Set<WholesalerBeer>().Where(wb => wb.BeerId == id).Select(wb => wb.WholesalerId).ToList();
            if (wholesalers != null)
            {
                
                foreach (Guid ws in wholesalers)
                {
                    var wholesaler = Context.Set<Wholesaler>().Where(w => wholesalers.Contains(ws)).Select(w => w.Name).SingleOrDefault();
                    WholeSalersName.Add(wholesaler);
                }
            }
            return WholeSalersName;
        }

        public void Delete(Guid idBeer, Guid idWholesaler)
        {
            WholesalerBeer _wholesalerBeer = context.WholesalerBeer.FirstOrDefault(wb => wb.BeerId == idBeer && wb.WholesalerId == idWholesaler);
            context.WholesalerBeer.Remove(_wholesalerBeer);
            context.SaveChanges();
        }
    }
}
