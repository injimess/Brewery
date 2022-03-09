using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryBusiness.DTOs
{
    public class SummaryDTO
    {
        public List<QuoteDetailsDTO> AvailableBeers { get; set; }

        public List<QuoteDetailsDTO> NotInStockBeers { get; set; }

        public List<QuoteDetailsDTO> NotExistingBeers { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalPrice { get; set; }

        public SummaryDTO()
        {
            AvailableBeers = new List<QuoteDetailsDTO>();
            NotExistingBeers = new List<QuoteDetailsDTO>();
        }
    }
}
