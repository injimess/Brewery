using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryBusiness.DTOs
{
    public class BeerDetailsDTO
    {
        public string Beer { get; set; }
        public string Brewery { get; set; }
        public List<string> Wholesalers { get; set; }
    }
}
