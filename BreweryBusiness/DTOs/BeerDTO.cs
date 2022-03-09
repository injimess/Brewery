using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryBusiness.DTOs
{
    public class BeerDTO
    {
        public Guid BreweryId { get; set; }
        [Required(ErrorMessage = "Name Required")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Alcohol Percentage Required")]
        public Decimal AlcoholPercentage { get; set; }
        [Required(ErrorMessage = "Price Required")]
        public Decimal Price { get; set; }
    }

}
