using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreweryBusiness.Services.Interfaces;
using BreweryBusiness.DTOs;
using BreweryData.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreweryApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private IBeerService _beerService;
        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;

        }
        // Get beers by brewery and wholesalers
        [HttpGet]
        public ActionResult<IEnumerable<BeerDetailsDTO>> GetAllBeers()
        {
            var beers = _beerService.GetAllBeers();
            if (beers == null)
                return NotFound();
            return Ok(beers);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult<Beer> CreateBeer([FromForm] BeerDTO newBeer)
        {
            try
            {
                if (newBeer == null)
                    return BadRequest("Beer object is null");
                Beer beer = new Beer();
                beer.BreweryId = newBeer.BreweryId;
                beer.Name = newBeer.Name;
                beer.Price = newBeer.Price;
                beer.AlcoholPercentage = newBeer.AlcoholPercentage;
                var beerCreated = _beerService.AddBeer(beer);
                return Ok(beerCreated);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
            
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult<String> Delete(Guid id)
        {
            if (_beerService.GetBeer(id) == null)
                return NotFound();
            else
                _beerService.DeleteBeer(id);
            return "Beer Deleted Successfully";
        }
    }
}
