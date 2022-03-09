using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryBusiness.DTOs
{
    public class WholesalerBeerDTO
    {

        public Guid WholesalerId { get; set; }

        public Guid BeerId { get; set; }

        public long Quantity { get; set; }
    }
}
