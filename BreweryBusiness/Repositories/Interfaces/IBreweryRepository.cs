using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryData.Entities;

namespace BreweryBusiness.Repositories.Interfaces
{
    public interface IBreweryRepository
    {
        public Brewery GetBrewery(Guid id);
    }
}
