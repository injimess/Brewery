using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryBusiness.DTOs
{
    public class QuoteRequestDTO
    {
        public Guid WholesalerId { get; set; }

        public List<QuoteDetailsDTO> QuoteDetails { get; set; }

        public QuoteRequestDTO()
        {
            QuoteDetails = new List<QuoteDetailsDTO>();
        }
    }
}
