using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository.Interface;

namespace AngularApi.Controllers
{
    [EnableCors("AllowAll")]
    public class CountryController : ControllerBase
    {
        private readonly IRegionsRepo  _regionsRepo;
        public CountryController(IRegionsRepo regionsRepo)
        {
            _regionsRepo = regionsRepo;
        }

        [HttpGet("GetCountry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<CountryModel>> GetCountry()
        {
            var countries = _regionsRepo.GetCountry().ToList();

            if (countries != null && countries.Any())
            {
                return Ok(countries);
            }

            return NoContent();
        }



        [HttpGet("GetStates")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<StateModel>> GetStates()
        {
            var States = _regionsRepo.GetState().ToList();

            if (States !=null && States.Any())
            {
                return States;
            }

            return NoContent();

        }

        [HttpGet("GetCities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<CityModel>> GetCities()
        {
            var Cities = _regionsRepo.GetCity().ToList();

            if (Cities !=null && Cities.Any())
            {
                return Ok(Cities);
            }
            return NoContent();
        }
    }
}
