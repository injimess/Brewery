using BreweryData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryData
{
    public class BreweryDbContext : DbContext
    {
        public BreweryDbContext(DbContextOptions<BreweryDbContext> opt) : base(opt)
        {

        }
        public virtual DbSet<Beer> Beer { get; set; }
        public virtual DbSet<Brewery> Brewery { get; set; }
        public virtual DbSet<Wholesaler> Wholesaler { get; set; }
        public virtual DbSet<WholesalerBeer> WholesalerBeer { get; set; }
        

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseSqlServer(@"Server=DESKTOP-B7RHC4D\MSSQLSERVER01;Database=Brewery;Trusted_Connection=True;");
        //}
    }
}
