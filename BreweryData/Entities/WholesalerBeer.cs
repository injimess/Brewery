using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryData.Entities
{
    public class WholesalerBeer
    {
        public Guid Id { get; set; }
        public Guid WholesalerId { get; set; }
        public Guid BeerId { get; set; }
        public long Quantity { get; set; }
        public virtual Beer Beer { get; set; }
        public virtual Wholesaler Wholesaler { get; set; }
    }
}
