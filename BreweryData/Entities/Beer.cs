using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryData.Entities
{
    public class Beer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid BreweryId { get; set; }
        public String Name { get; set; }
        public Decimal AlcoholPercentage { get; set; }
        public Decimal Price { get; set; }
        public virtual Brewery Brewery { get; set; }
    }
}
