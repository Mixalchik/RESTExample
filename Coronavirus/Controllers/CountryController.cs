using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coronavirus.BLL.Abstract;
using Coronavirus.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coronavirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        [Route("{code}")]
        public async Task<Country> Get(string code)
        {
            return await countryService.Get(code);
        }

        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return countryService.Get();
        }

        [HttpPost]
        public async Task<Country> Add([FromBody] Country country)
        {
            return await countryService.Add(country);
        }

        [HttpPut]
        public async Task<Country> Update([FromBody] Country country)
        {
            return await countryService.Update(country);
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<bool> Delete(string code)
        {
            return await countryService.Delete(code);
        }
    }
}