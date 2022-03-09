using BreweryBusiness.Services.Interfaces;
using BreweryData.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreweryBusiness.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreweryApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WholesalerController : ControllerBase
    {
        private IWholesalerBeerService _wbService;
        public WholesalerController(IWholesalerBeerService wbService)
        {
            _wbService = wbService;
        }
        // POST api/<WholesalerController>
        [HttpPost]
        public ActionResult<WholesalerBeer> AddBeerToWholesaler(Guid idBeer, Guid idWholesaler, long Quantity)
        {
            return Ok(_wbService.Add(idBeer, idWholesaler, Quantity));
        }

        // PUT api/<WholesalerController>/5
        [HttpPut]
        public ActionResult<String> Put(Guid idBeer, Guid idWholesaler, long newQuantity)
        {
            _wbService.Update(idBeer, idWholesaler,newQuantity);
            return "Quantity updated successfully";
        }

        // DELETE api/<WholesalerController>/5
        [HttpDelete]
        public ActionResult<String> Delete(Guid idBeer, Guid idWholesaler)
        {
            _wbService.Delete(idBeer, idWholesaler);
            return "Beer deleted from wholesaler";

        }

        [HttpPost]
        public ActionResult<SummaryDTO> Summary(Guid idWholesaler, Dictionary<Guid,int> QuoteDetails)
        {
            var quoteSummary = _wbService.RequestQuote(idWholesaler,QuoteDetails);
            if (quoteSummary == null)
                return NotFound();
            return Ok(quoteSummary);

        }
    }
}
